namespace PaymentSwitch.Domain.Enums
{
    public enum TransactionStep
    {
        Execute,  // اجرای اصلی
        Advice,
        Reverse
    }
}
