using TextBasedConsoleGame;

Player player = new Player();
Skeleton skeleton = new Skeleton();
Zombie zombie = new Zombie();
Werewolf werewolf = new Werewolf();
int encounterCounter = 1;
int standardWeaponDamage = player.WeaponDamage;


MainMenu();

void MainMenu()
{
    bool keepAlive = true;

    while (keepAlive)
    {
        Console.Clear();
        Console.WriteLine("Greetings\n");
        Console.WriteLine("1. Create Character");
        Console.WriteLine("2. Quit game.");

        int choice;
        do
        {
            Console.Write("\nWhat is your choice?: ");
        } while(!int.TryParse(Console.ReadLine(),out choice) ||  choice < 1 || choice > 2);

        switch (choice)
        {
            case 1:
                CreateCharacter();
                keepAlive = false;
                break;
            case 2:
                keepAlive = false;
                break;
        }
    }
}

void Room()
{
    Console.Clear();
    Room room = new Room();

    if(room.Torch == true)
        SlowWriter.Write("The room has a torch, you can clearly see your surroundings in here.\n");

    else
    {
        SlowWriter.Write("The room is very dark, there are no torches on the walls.");
        SlowWriter.Write("Your damage will be reduced in these conditions.\n");
        player.WeaponDamage -= 2;
        SlowWriter.Write($"Your weapon now deals {player.WeaponDamage} damage.\n");
    }

    if (room.Doors <= 1)
        SlowWriter.Write($"You see {room.Doors} door leading out of the room.\n");
    else
    {
        SlowWriter.Write($"You see {room.Doors} doors leading out of the room.\n");
        Console.Write("Would you like to go left or right?: ");
        var doorChoice = Console.ReadLine();

        while(doorChoice != "left" &&  doorChoice != "right")
        {
            Console.Write("Left or right, make your choice: ");
            doorChoice = Console.ReadLine().ToLower();
        }
    }

    Encounter();
}


void CreateCharacter()
{
    Console.Clear();
    player = new Player();
    Console.Write("What is your name? ");
    player.Name = Console.ReadLine();
    while(player.Name == "")
    {
        Console.Clear();
        Console.WriteLine("You need a name, otherwise I wont know what to call you.");
        Console.Write("What is your name?: ");
        player.Name = Console.ReadLine();
    }
    Console.Clear();

    Console.WriteLine("What weapon would you like to take with you?");
    Console.WriteLine("1. Sword (Hitchance of 75%, Damage 10)\n");
    Console.WriteLine("2. Bow (Hit chance of 60%, Damage 12)\n");
    Console.WriteLine("3. Bare hands (Hit chance of 85%, Damage 5)\n");

    int weaponChoice;
    do
    {
        Console.Write("Enter your choice (1, 2, 3): ");
    } while (!int.TryParse(Console.ReadLine(), out weaponChoice) || weaponChoice < 1 || weaponChoice > 3);

    SetPlayerWeapon(player, weaponChoice);

    Console.Clear();
    Console.WriteLine($"Character Name: {player.Name.ToUpper()}");

    Console.WriteLine($"You choice of weapon: {player.WeaponName.ToUpper()}");
    Console.WriteLine($"Your damage currently is: {player.WeaponDamage}\n");
    Console.Write("Are you sure you want to start the game like this?: ");
    var accept = Console.ReadLine();

    while (accept != "yes" && accept != "no")
    {
        Console.Write("It's a simple yes or no answer: ");
        accept = Console.ReadLine().ToLower();
    }

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

void SetPlayerWeapon(Player player, int choice)
{
    switch (choice)
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
}

void Encounter()
{

    if (encounterCounter == 1)
    {
        encounterCounter++;
        skeleton.MonsterArival();
        SneakAttempt();
        SkeletonFight();
    }
    if (encounterCounter == 2)
    {
        encounterCounter++;
        zombie.MonsterArival();
        SneakAttempt();
        ZombieFight();
    }
    if (encounterCounter == 3)
    {
        encounterCounter++;
        werewolf.MonsterArival();
        SneakAttempt();
        WerewolfFight();
    }
    if (encounterCounter == 4)
    {
        encounterCounter = 1;
        YouBeatTheGame();
    }

}

void SneakAttempt()
{
    Console.Write("Attack or try to sneak around?: ");
    var choice = Console.ReadLine().ToLower();
    Console.WriteLine();
    while (choice != "sneak around" && choice != "attack")
    {
        Console.WriteLine($"{choice} is not an accepted response.\n");
        Console.WriteLine("Select between 'sneak around' and 'attack'");
        choice = Console.ReadLine().ToLower();
    }

    if (choice == "sneak around")
    {
        var sneakChance = new Random().Next(2) == 0;
        if (sneakChance == true)
        {
            SuccessfullSneak();
        }

        else
            Console.WriteLine("\nThe fiend notices you!");
    }
    Console.WriteLine("Attack it is, queue boss music!\n");
}

void ZombieFight()
{
    Zombie zombie = new Zombie();

    while (player.HealthPoints > 0 && zombie.HealthPoints > 0)
    {
        player.Attack(zombie);
        if (zombie.HealthPoints > 0)
            zombie.Attack(player);
    }

    if (zombie.HealthPoints <= 0)
    {
        Console.WriteLine("\nThe zombie is dead.");
        player.ShowCurrentPlayerHealth();
        player.DrinkHealingPotion();
        Console.Write("\nPress any key to advance into the next room...");
        Console.ReadKey();
        Room();
    }

    else
    {
        GameOver();
    }
}

void SkeletonFight()
{
    Skeleton skeleton = new Skeleton();

    while (player.HealthPoints > 0 && skeleton.HealthPoints > 0)
    {
        player.Attack(skeleton);
        if (skeleton.HealthPoints > 0)
            skeleton.Attack(player);
    }

    if (skeleton.HealthPoints <= 0)
    {
        Console.WriteLine("\nThe skeleton is dead.");
        player.ShowCurrentPlayerHealth();
        player.DrinkHealingPotion();
        Console.Write("\nPress any key to advance into the next room...");
        Console.ReadKey();
        Room();
    }

    else
    {
        GameOver();
    }
}

void WerewolfFight()
{
    Werewolf werewolf = new Werewolf();

    while (player.HealthPoints > 0 && werewolf.HealthPoints > 0)
    {
        player.Attack(werewolf);
        if (werewolf.HealthPoints > 0)
            werewolf.Attack(player);
    }

    if (werewolf.HealthPoints <= 0)
    {
        Console.WriteLine("\nThe skeleton is dead.");
        player.ShowCurrentPlayerHealth();
        player.DrinkHealingPotion();
        Console.Write("\nPress any key to advance into the next room...");
        Console.ReadKey();
        Room();
    }

    else
    {
        GameOver();
    }
}

void SuccessfullSneak()
{
    Console.WriteLine("\nYou creap your way to the door without alarming the creature.");
    Console.WriteLine("You stumble into a new room.\n");
    Console.Write("Press any key to continue forwards.");
    Console.ReadKey();
    Room();
}

void YouBeatTheGame()
{
    SlowWriter.Write("\nTurns out that this was the last room, you can see an exit ahead of you!");
    Console.Write("\nPress any key to return to the main menu.");
    Console.ReadKey();
    MainMenu();
}

void GameOver()
{
    Console.WriteLine("\nSadly, you have perished.");
    Console.Write("Press any key to return to the main menu.");
    Console.ReadKey();
    MainMenu();
}