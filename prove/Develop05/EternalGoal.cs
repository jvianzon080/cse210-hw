namespace EternalQuest
{
    class EternalGoal : Goal
    {
        private int timesCompleted;

        public EternalGoal(string name, int points, int timesCompleted = 0) : base(name, points)
        {
            this.timesCompleted = timesCompleted;
        }

        public override int RecordProgress()
        {
            timesCompleted++;
            return Points;
        }

        public override string GetStatus()
        {
            return $"{Name} - Completed {timesCompleted} times";
        }

        public override string Serialize()
        {
            return $"EternalGoal:{Name},{Points},{timesCompleted}";
        }
    }
}
