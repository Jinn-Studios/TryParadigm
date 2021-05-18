using System.Linq;

public class ConsultantRepo
{
    private readonly string _conn;
    public ConsultantRepo(string conn) { _conn = conn; }

    public TryParadigm.Enums.Result TryGetSSN(int? entityID, out string outSSN)
    {
        outSSN = string.Empty;
        try
        {
            if (entityID.Value < 0)
                return TryParadigm.Enums.Result.Failure;

            using var context = new DbContext(_conn);
            outSSN = context.Consultants.Where(x => x.EntityID == entityID)
                .Select(x => x.SSN).SingleOrDefault();

            if (outSSN == null)
                return TryParadigm.Enums.Result.Failure;

            return TryParadigm.Enums.Result.Success;
        }
        catch
        {
            return TryParadigm.Enums.Result.Exception;
        }
    }
}