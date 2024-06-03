namespace EternalQuest
{
    class SimpleGoal : Goal
    {
        public SimpleGoal(string name, int points, bool isComplete = false) : base(name, points)
        {
            IsComplete = isComplete;
        }

        public override int RecordProgress()
        {
            if (!IsComplete)
            {
                IsComplete = true;
                return Points;
            }
            return 0;
        }

        public override string GetStatus()
        {
            return $"{Name} - {(IsComplete ? "[X]" : "[ ]")}";
        }

        public override string Serialize()
        {
            return $"SimpleGoal:{Name},{Points},{IsComplete}";
        }
    }
}
