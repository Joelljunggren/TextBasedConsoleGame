using TextBasedConsoleGame;

Player player = new Player();
Skeleton skeleton = new Skeleton();
Zombie zombie = new Zombie();
int roomsCleared = 0;
int encounterCounter = 0;


MainMenu();

void MainMenu()
{
    bool keepAlive = true;

    while (keepAlive)
    {
        Console.Clear();
        Console.WriteLine("Greetings\n");
        Console.WriteLine("1. Create Character");
        Console.WriteLine("2. Proceed into dungeon");
        Console.WriteLine("3. Quit game.");

        Console.Write("\nWhat is your choice? ");
        var choice = Convert.ToInt32(Console.ReadLine());

        switch(choice)
        {
            case 1:
                CreateCharacter();
                keepAlive = false;
                break;
            case 2:
                Room();
                keepAlive = false;
                break;
            case 3:
                keepAlive = false;
                break;
        }
    }
}

void Room()
{
    Room room = new Room();
    Console.Clear();
    if(room.Torch == true)
        SlowWriter.Write("The room has a torch, you can clearly see your surroundings in here.\n");
    else
    {
        SlowWriter.Write("The room is very dark, there are no torches on the walls.");
        SlowWriter.Write("Your damage will be reduced in these conditions.\n");
        player.WeaponDamage -= 2;
    }

    if (room.Doors <= 1)
        SlowWriter.Write($"You see {room.Doors} door leading out of the room.\n");
    else
    {
        SlowWriter.Write($"You see {room.Doors} doors leading out of the room.\n");
        Console.Write("Would you like to go left or right?");
        var doorChoice = Console.ReadLine();
    }

    Encounter();
    //    YouBeatTheGame();
}


void CreateCharacter()
{
    Console.Clear();
    player = new Player();
    Console.Write("What is your name? ");
    player.Name = Console.ReadLine();
    Console.Clear();

    Console.WriteLine("What weapon would you like to take with you?");
    Console.WriteLine("1. Sword (Hitchance of 75%, Damage 10)\n");
    Console.WriteLine("2. Bow (Hit chance of 60%, Damage 12)\n");
    Console.WriteLine("3. Bare hands (Hit chance of 85%, Damage 5)\n");
    var weaponChoice = Convert.ToInt32(Console.ReadLine());

    switch (weaponChoice)
    {
        case 1:
            player.WeaponDamage = 10;
            player.WeaponName = "Sword";
            break;
        case 2:
            player.WeaponDamage = 12;
            player.WeaponName = "Bow";
            break;
        case 3:
            player.WeaponDamage = 5;
            player.WeaponName = "Fist";
            break;
    }

    Console.Clear();
    Console.WriteLine($"Character Name: {player.Name.ToUpper()}");

    Console.WriteLine($"You choice of weapon: {player.WeaponName.ToUpper()}");
    Console.WriteLine($"Your damage currently is: {player.WeaponDamage}\n");
    Console.WriteLine("Are you sure you want to start the game like this?");
    Console.WriteLine("YES to return to start your game,\nNO to start character creation again.");
    var accept = Console.ReadLine();

    switch (accept)
    {
        case "yes":
            Room();
            break;
        case "no": 
            CreateCharacter(); 
            break;
    }
}

void Encounter()
{
    encounterCounter++;

    if (encounterCounter == 1)
    {
        skeleton.MonsterArival();
        SneakAttempt();
        SkeletonFight();
    }
    if(encounterCounter == 2)
    {
        zombie.MonsterArival();
        SneakAttempt();
        ZombieFight();
    }
    if(encounterCounter == 3)
    {
        
    }
}

void SneakAttempt()
{
    Console.Write("Attack or try to sneak around?: ");
    var choice = Console.ReadLine().ToLower();
    Console.WriteLine();
    if (choice == "sneak around")
    {
        var sneakChance = new Random().Next(2) == 0;
        if (sneakChance == true)
        {
            SuccessfullSneak();
        }

        else
            Console.WriteLine("The skeleton notices you!");
    }
    Console.WriteLine("Attack it is, queue boss music!");
}

void ZombieFight()
{
    //Måste finnas ett bättre sätt med rng för skeleton och player hitchance

    while (player.HealthPoints >= 0 && zombie.HealthPoints >= 0)
    {
        if(player.HealthPoints >= 0)
        {
            PlayerAttack();
            if(player.PlayerHitChance() <= 4)
            {
                Console.WriteLine("You missed!\n");
            }
            else
            {
                zombie.HealthPoints -= player.WeaponDamage;
                zombie.ShowHealth();
                Console.WriteLine();
            }
        }

        if (zombie.HealthPoints >= 0)
        {
            SkeletonAttack();
            if (zombie.HitChance() <= 6)
            {
                Console.WriteLine("It missed!\n");
            }
            else
            {
                player.HealthPoints -= zombie.Damage;
                player.ShowHealth();
                Console.WriteLine();
            }

        }
    }

    if(zombie.HealthPoints <= 0)
    {
        roomsCleared++;
        Console.WriteLine("\nThe skeleton is dead.");
        Console.WriteLine("Press any key to advance into the next room...");
        Console.ReadKey();
        Room();
    }

    if(player.HealthPoints <= 0)
    {
        Console.WriteLine("\nSadly, you have perished.");
        Console.WriteLine("Press any key to return to the main menu.");
        Console.ReadKey();
        MainMenu();
    }
    

}

void SkeletonFight()
{
    //Måste finnas ett bättre sätt med rng för skeleton och player hitchance

    while (player.HealthPoints >= 0 && skeleton.HealthPoints >= 0)
    {
        if (player.HealthPoints >= 0)
        {
            PlayerAttack();
            if (player.PlayerHitChance() <= 4)
            {
                Console.WriteLine("You missed!\n");
            }
            else
            {
                skeleton.HealthPoints -= player.WeaponDamage;
                skeleton.ShowHealth();
                Console.WriteLine();
            }
        }

        if (skeleton.HealthPoints >= 0)
        {
            SkeletonAttack();
            if (skeleton.HitChance() <= 6)
            {
                Console.WriteLine("It missed!\n");
            }
            else
            {
                player.HealthPoints -= skeleton.Damage;
                player.ShowHealth();
                Console.WriteLine();
            }

        }
    }

    if (skeleton.HealthPoints <= 0)
    {
        roomsCleared++;
        Console.WriteLine("\nThe skeleton is dead.");
        Console.WriteLine("Press any key to advance into the next room...");
        Console.ReadKey();
        Room();
    }

    if (player.HealthPoints <= 0)
    {
        Console.WriteLine("\nSadly, you have perished.");
        Console.WriteLine("Press any key to return to the main menu.");
        Console.ReadKey();
        MainMenu();
    }


}

void SuccessfullSneak()
{
    roomsCleared++;
    Console.WriteLine("You creap your way to the door without alarming the skeleton.");
    Console.WriteLine("You stumble into a new room.\n");
    Console.WriteLine("Press any key to continue forwards.");
    Console.ReadKey();
    Room();
}

void SkeletonAttack()
{
    Console.WriteLine($"The skeleton starts it's attack and..");
    Thread.Sleep(600);
    skeleton.HitChance();
}

void PlayerAttack()
{
    Console.WriteLine($"You raise your {player.WeaponName} and..");
    Thread.Sleep(600);
    player.PlayerHitChance();
}

void YouBeatTheGame()
{
    Console.WriteLine("\nCongratulations, you escaped!");
}

