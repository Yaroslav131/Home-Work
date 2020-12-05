using static System.Console;

namespace LineOutput
{
    public class Output
    {
        public void ShowTutorial()
        {
            WriteLine("Wellcom to Princess game\n" +
                "Aims of game:\n" +
                "Save Princess on the other side of the field. \n" +
                "Rules of game:\n" +
                "1)Hero have 10 HP.\n" +
                "2)Field have 10 mins on itself, with random damage from 1 to 10.\n" +
                "3)Mins explode ones time.\n" +
                "Control:\n" +
                "You can move Hero with AWSD or arrows or NumPad.");
            WriteLine("------------------------------");
        }
    }
}
