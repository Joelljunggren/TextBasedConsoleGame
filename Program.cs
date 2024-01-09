using TextBasedConsoleGame;

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
                break;
            case 2:
                RunGame();
                break;
            case 3:
                keepAlive = false;
                break;
        }
    }
}

void RunGame()
{

}

void CreateCharacter()
{
    Console.Clear();
    var player = new Player();
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
            player.HitChance = 75;
            break;
        case 2:
            player.WeaponDamage = 12;
            player.WeaponName = "Bow";
            player.HitChance = 60;
            break;
        case 3:
            player.WeaponDamage = 5;
            player.WeaponName = "Bare hands";
            player.HitChance = 85;
            break;
    }

    Console.Clear();
    Console.WriteLine($"Character name: {player.Name.ToUpper()}");
    Console.WriteLine($"You choice of weapon: {player.WeaponName.ToUpper()}");
    Console.WriteLine($"Your damage currently is: {player.WeaponDamage}");
    Console.WriteLine($"Your hit chance currently sits at: {player.HitChance}%\n");
    Console.WriteLine("Are you sure you want to start the game like this?");
    Console.WriteLine("YES to start game, NO to start character creation again.");
    var accept = Console.ReadLine();

    switch (accept)
    {
        case "yes":
            RunGame();
            break;
        case "no": 
            CreateCharacter(); 
            break;
    }
}