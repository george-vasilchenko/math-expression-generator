namespace Meg.Core.Exercises
{
    public abstract class ExerciseTopic
    {
        protected ExerciseTopic(ExerciseTopicConfig config) => Config = config;

        public ExerciseTopicConfig Config { get; private set; }

        public abstract IEnumerable<Exercise> GetExercises(byte count);
    }
}
