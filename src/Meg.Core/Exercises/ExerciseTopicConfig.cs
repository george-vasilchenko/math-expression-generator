namespace Meg.Core.Exercises
{
    public abstract class ExerciseTopicConfig
    {
        protected ExerciseTopicConfig(string label, double minValue, double maxValue)
        {
            if (minValue >= maxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(minValue), "Min value must be less than max value");
            }

            MaxValue = maxValue;
            MinValue = minValue;
            Label = label;
        }

        public string Label { get; }
        public double MaxValue { get; }
        public double MinValue { get; }

        public abstract int GetExerciseCountLimit();
    }
}
