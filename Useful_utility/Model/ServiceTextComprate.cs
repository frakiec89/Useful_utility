namespace Useful_utility.Model
{
    public class TextComprate
    {
        public string ValueText { get; set; }
        public string IntupText { get; set; }


        public bool? IsGoog
        {
            get
            {
                if (string.IsNullOrEmpty(IntupText))
                    return null;

                if (ValueText == IntupText)
                    return true;

                if (string.IsNullOrEmpty(ValueText) && IntupText.ToLower() == "space")
                    return true;

                if (string.IsNullOrEmpty(ValueText) && IntupText.ToLower() == "-")
                    return true;


                if (string.IsNullOrEmpty(ValueText) && IntupText.ToLower() == " ")
                    return true;


                return false;
            }
        }
    }

    public class ServiceTextComprate
    {
        public List<TextComprate> Compresses { get; set; } = new List<TextComprate>();


        public ServiceTextComprate()
        {
            Compresses = new List<TextComprate>();
        }

        public ServiceTextComprate(string content)
        {
            var r = content.Split('\n');

            foreach (var r2 in r)
            {
                Compresses.Add(new TextComprate { ValueText = r2.Trim() });
            }
        }

    }
}