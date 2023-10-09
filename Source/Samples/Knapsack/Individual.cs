using System.Text;

namespace Knapsack;

public class Individual
{
    public List<Envelope> Envelopes { get; } = new();

    public override string ToString()
    {
        var sb = new StringBuilder();
        var i = 1;
        
        foreach (var env in Envelopes)
        {
            sb.AppendLine($"------- ENVELOPE {i++} -------");
            sb.Append(env);
        }

        return sb.ToString();
    }
}