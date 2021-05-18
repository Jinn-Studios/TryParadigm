public partial class ConsultantService : GuardClauses.Core.IService
{
    private readonly ConsultantRepo _repo;
    public ConsultantService(ConsultantRepo repo) { _repo = repo; }

    public SocialSecurityNumber GetSSN(int entityID)
    {
        var dbResult = _repo.TryGetSSN(entityID, out string ssn);
        if (dbResult != TryParadigm.Enums.Result.Success)
            return SocialSecurityNumber.Empty;

        var parseResult = SocialSecurityNumber.TryParse(ssn, out SocialSecurityNumber objSSN);
        if (parseResult == false)
            return SocialSecurityNumber.Empty;

        return objSSN;
    }
}