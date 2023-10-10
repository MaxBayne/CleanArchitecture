using CleanArchitecture.Domain.Abstract;

namespace CleanArchitecture.Domain.Entities
{
    public class Tax:Entity<int>
    {
        #region Properites

        public string TaxName { get; private set; }
        public decimal TaxValue { get; private set; }
        public decimal TaxPercent { get; private set; }
        public bool IsActive { get; private set; }

        public int OrderItemId { get; private set; }
        public int OrderId { get; private set; }

        #endregion

        #region Constructors

        public Tax()
        {
            TaxName = string.Empty;
            TaxValue = 0;
            TaxPercent = 0;
            IsActive = true;
        }
        public Tax(string taxName, decimal taxValue, bool isActive,int orderItemId,int orderId)
        {
            TaxName = taxName;
            TaxValue = taxValue;
            TaxPercent = 0;
            IsActive = isActive;
            
            OrderItemId = orderItemId;
            OrderId = orderId;
        }
        public Tax(string taxName, decimal taxPercent, int orderItemId, int orderId)
        {
            TaxName = taxName;
            TaxValue = 0;
            TaxPercent = taxPercent;
            IsActive = true;

            OrderItemId = orderItemId;
            OrderId = orderId;
        }

        #endregion

        #region Methods

        public void ChangeTaxName(string taxName)
        {
            TaxName = taxName;
        }

        public void SetTaxValue(decimal taxValue)
        {
            TaxValue = taxValue;
        }

        public void SetTaxPercent(decimal taxPercent)
        {
            TaxPercent = taxPercent;
        }

        public void SetTaxActive()
        {
            IsActive = true;
        }

        public void SetTaxDisActive()
        {
            IsActive = false;
        }

        #endregion

    }
}
