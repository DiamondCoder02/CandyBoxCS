namespace CandyBoxCS.src
{
    public interface IVariables
    {
#pragma warning disable CA2211 // Non-constant fields should not be visible
        public static bool debugMode = false;
        public static string language = "en";

        public static int candies = -1;
        public static int candyMultip = 1;
        public static int lollipops = -1;
        public static double loliMultip = 0.01;
        public static int chocolate = -1;
        public static int painsAuChocolat = -1;
        public static string currentLocation = "Clicker";

        public static int eatenCandies = 0;
        public static int thrownCandies = 0;

        public static int maxHealth = 100;
        public static int currentHealth = 100;

        public static bool[] unlockedMenus = [
            false, //1 1. BoughtManuBar ->
                   //It get's some style and reveals that you can unlock
            false, //8 2. Config
            false, //7 3. Save? 
            false, //2 4. HealthBar
            false, //3 6. Inventory
            false, //4 5. Map
            false, //5 7. LollipopFarm
            false //6 8. Cauldron
        ];

        // This is used if the control is discovered
        // If not, on the left side it shows "? - ???"
        // If one is discovered it will be true and show "M - Main map"
        public static bool[][] foundControls = [
        // - Side Scrolling fight
        // + Special, choose but also fight
        // | Lot of choices
        [ // Clicker
            false, // Eat Candy
            false, // Throw Candy
            false, // Request New feature
        ],
        [ // Main Map
            //Special || ACTIVATE ONLY ONCE
            false, // 3 chocolate under tree
            // Level 1
            false, // Squirel Tree
            false, // Lonely house (Giant Candy Box)
            false, // - Desert
            // Level 2
            false, // + The Desert Fortress
            false, // The Lollipop farm
            false, // - The bridge
            false, // + The Cave entrance
            false, // The Wishing Well
            false, // Sorceress' Hut
            // Level 3
            false, // + The Pier
            false, // - The forest
            false, // | The Lighthouse
            // Level 4
            false, // + The (deep) hole
            false, // - Castle Enterance
            false, // The Castle
            false, // | Dragon
        ],
        [ // Castle
            false, // Stomper Room
            false, // Dark Room
            false, // Spiky Room
            false, // Furnace
            false, // Giant Mouse
            false, // Tower
            false, // Stairs
        ]
        ];

        public static bool[] inventoryItems = [
            false, // Main Map
            false, // Time Ring
            false, // Third house key
            false, // Beginer Grimore spell book thingie

            false, // Desert Bird feather
            false, // Pogo Stick
            false, // Heart plug
            false, // Advanced grimore

            false, // Magical sponge
            false, // Shell powder
            false, // Red shark fin
            false, // Black magic grimore

            false, // Green shark fin
            false, // Purple shark fin 
            false, // Heart pendant
            false, // Desert fortress key

            false, // Unicorn horn
            false, // Xinopherydon claw
            false, // PitchFork
            false, // Talking canddy

            false, // P
            false, // L
            false, // A
            false, // Y
        ];
    }
}
