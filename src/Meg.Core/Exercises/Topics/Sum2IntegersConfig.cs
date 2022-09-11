namespace Meg.Core.Exercises.Topics
{
    public class Sum2IntegersConfig : ExerciseTopicConfig
    {
        public Sum2IntegersConfig(string label, double maxValue, double minValue) : base(label, maxValue, minValue)
        {
        }

        public override int GetExerciseCountLimit() => (int)Math.Pow(MaxValue - MinValue + 1, 2.0);
    }
}
