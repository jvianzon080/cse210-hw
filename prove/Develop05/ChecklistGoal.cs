namespace EternalQuest
{
    class ChecklistGoal : Goal
    {
        private int targetCount;
        private int currentCount;
        private int bonusPoints;

        public ChecklistGoal(string name, int points, int targetCount, int currentCount = 0, int bonusPoints = 0) 
            : base(name, points)
        {
            this.targetCount = targetCount;
            this.currentCount = currentCount;
            this.bonusPoints = bonusPoints;
        }

        public override int RecordProgress()
        {
            if (currentCount < targetCount)
            {
                currentCount++;
                if (currentCount == targetCount)
                {
                    IsComplete = true;
                    return Points + bonusPoints;
                }
                return Points;
            }
            return 0;
        }

        public override string GetStatus()
        {
            return $"{Name} - Completed {currentCount}/{targetCount} times {(IsComplete ? "[X]" : "[ ]")}";
        }

        public override string Serialize()
        {
            return $"ChecklistGoal:{Name},{Points},{targetCount},{currentCount},{bonusPoints}";
        }
    }
}
