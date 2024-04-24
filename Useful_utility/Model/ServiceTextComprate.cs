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



                if (string.IsNullOrEmpty(ValueText) && IntupText.ToLower() == "space")
                    return true;

                if (string.IsNullOrEmpty(ValueText) && IntupText.ToLower() == "-")
                    return true;


                if (string.IsNullOrEmpty(ValueText) && IntupText.ToLower() == " ")
                    return true;
                return CompreteForSpace(ValueText.Trim() , IntupText.Trim());

                return false;
            }
        }

        private bool? CompreteForSpace(string valueText, string intupText)
        {

            int st1 = valueText.Select(x=>x == ' ').Count();
            int st2 = intupText.Select(x => x == ' ').Count();

            if(st1>st2)
                return false;



            List<string> strings1 = new List<string>();

            foreach (var item in valueText.Split(' '))
            {
                if(String.IsNullOrWhiteSpace(item) == false)
                    strings1.Add(item);
            }



            List<string> strings2 = new List<string>();

            foreach (var item in intupText.Split(' '))
            {
                if (String.IsNullOrWhiteSpace(item) == false)
                    strings2.Add(item);
            }

               if(strings1.Count != strings2.Count)
                    return false;

            for (int i = 0; i < strings1.Count; i++)
            {
                if (string.Compare(strings1[i] , strings2[i] )!= 0)
                    return false;
            }


            string s  = valueText.Replace(" ", "");
            string s1 = intupText.Replace(" ", "");

            if(string.Compare(s , s1) == 0)
                return true;
            return false;


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