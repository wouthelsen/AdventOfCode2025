using AoCHelper;

namespace AOC.Solutions
{
    public abstract class MyBaseDay : BaseDay
    {
        public bool UseExample { get; set; } = false;

        public override string InputFilePath
        {
            get
            {
                var index = CalculateIndex().ToString("D2");

                if (UseExample)
                {
                    index += "-example";
                };

                return Path.Combine(InputFileDirPath, $"{index}.{InputFileExtension.TrimStart('.')}");
            }
        }

        protected string[] InputLines => File.ReadAllLines(InputFilePath);
    }
}