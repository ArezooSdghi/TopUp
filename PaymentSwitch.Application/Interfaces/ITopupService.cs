namespace TopUp
{
    public interface ITopupService
    {
        Task<bool> ChargeAsync(TopupRequest request);
    }
}
