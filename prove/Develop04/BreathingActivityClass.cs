public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
    {
        name = "Breathing";
        description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    protected override void PerformActivity()
    {
        int interval = duration / 2;  // Each breathing in/out cycle takes 2 seconds
        for (int i = 0; i < interval; i++)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(2);
            Console.WriteLine("Breathe out...");
            ShowCountdown(2);
        }
    }
}
