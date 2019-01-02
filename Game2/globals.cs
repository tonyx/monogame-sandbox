using System;
namespace Game2
{
    public static class Globals
    {
        public static int NUMBER_OF_BARS = 5;
        public static int NUMBER_OF_HORIZONTAL_BARS = 4;
        public static int BAR_X_SPEED = 0;
        public static int BAR_Y_SPEED = 3;
        public static int HORIZONTAL_BAR_UPPER_MARGIN = 100;

        public static int HORIZONTAL_BAR_X_SPEED = 0;
        public static int HORIZONTAL_BAR_Y_SPEED = 3;

        public static int MIN_X_DISTANCES_BETWEEN_BARS = 20;

        public static int SCREEN_HEIGTH = 480;
        public static int SCREEN_WIDTH = 800;

        public static int[] BAR_X_POSITIONS = new int[NUMBER_OF_BARS];
        public static int[] HORIZONTAL_BAR_X_POSITIONS = new int[NUMBER_OF_HORIZONTAL_BARS];

        public static int LEFT_X_BAR_MARGINS = 200;
        public static int LEFT_X_HORIZONTAL_BAR_MARGINS = 60;
        public static int RIGHT_X_BAR_MARGINS = 0;

        static Globals() {
            int interval = (SCREEN_WIDTH - (LEFT_X_BAR_MARGINS+RIGHT_X_BAR_MARGINS)) / NUMBER_OF_BARS;

            for (int i = 0; i < NUMBER_OF_BARS; i++)
            {
                BAR_X_POSITIONS[i] = LEFT_X_BAR_MARGINS + interval * i;
            }

            HORIZONTAL_BAR_X_POSITIONS[0] = BAR_X_POSITIONS[0] - 120;

            for (int i = 1; i < NUMBER_OF_HORIZONTAL_BARS; i++)
            {
                HORIZONTAL_BAR_X_POSITIONS[i] = BAR_X_POSITIONS[i-1] + 15;
            }
        }
    }
}
