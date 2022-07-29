Console.OutputEncoding = System.Text.Encoding.UTF8;

var mix = Directory.GetFiles(args[0]).Select(GetData).SelectMany(file => file).ToList();

while (true)
{
    var key = Random.Shared.Next(0, mix.Count);
    var option = Random.Shared.Next() % 2 == 0;
    var question = option ? mix[key].Key : mix[key].Value;
    var answer = !option ? mix[key].Key : mix[key].Value;

    Console.Write(question);
    Console.ReadKey();
    Console.WriteLine($"{question} - {answer}");
}

IEnumerable<KeyValuePair<string, string>> GetData(string path)
    => File.ReadAllLines(path)
        .Where(row => !row.StartsWith("//"))
        .Select(dictionary =>
        {
            var row = dictionary.Split('|').Select(r => r.Trim()).ToList();
            return new KeyValuePair<string, string>(row[0], row[1]);
        });