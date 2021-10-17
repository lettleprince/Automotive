// Group2: Jingfei Yao, Grace Pauly, Xiaotong Han.
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Automotive
{
    class ViewModel: INotifyPropertyChanged
    {
        #region Price Define
        public decimal OilChangePrice { get => 26m; }
        public decimal LubeJobPrice { get => 18m; }
        public decimal RadiatorFlushPrice { get => 30m; }
        public decimal TransmissionFlushPrice { get => 80m; }
        public decimal InspectionPrice { get => 15m; }
        public decimal MufflerReplancementPrice { get => 100m; }
        public decimal TireRotationPrice { get => 20m; }
        public decimal TaxPercentage { get => 0.06m; }
        private decimal LaborPerHourPrice { get => 20m; }
        #endregion

        #region OilLubeCharges
        private bool hasOilChange;
        public bool HasOilChange
        {
            get { return hasOilChange; }
            set { hasOilChange = value; propertyChanged(); }
        }
        private bool hasLubeJob;
        public bool HasLubeJob
        {
            get { return hasLubeJob; }
            set { hasLubeJob = value; propertyChanged(); }
        }

        private decimal OilLubeCharges()
        {
            decimal charges = 0m;
            charges += HasOilChange ? OilChangePrice : 0;
            charges += HasLubeJob ? LubeJobPrice : 0;
            return charges;
        }
        #endregion

        #region FlushCharges
        private bool hasRadiatorFlush;
        public bool HasRadiatorFlush
        {
            get { return hasRadiatorFlush; }
            set { hasRadiatorFlush = value; propertyChanged(); }
        }

        private bool hasTransmissionFlush;
        public bool HasTransmissionFlush
        {
            get { return hasTransmissionFlush; }
            set { hasTransmissionFlush = value; propertyChanged(); }
        }

        private decimal FlushCharges()
        {
            decimal charges = 0m;
            charges += HasRadiatorFlush ? RadiatorFlushPrice : 0;
            charges += HasTransmissionFlush ? TransmissionFlushPrice : 0;
            return charges;
        }
        #endregion

        #region MiscCharges
        private bool hasInspection;
        public bool HasInspection
        {
            get { return hasInspection; }
            set { hasInspection = value; propertyChanged(); }
        }

        private bool hasMufflerReplancement;
        public bool HasMufflerReplancement
        {
            get { return hasMufflerReplancement; }
            set { hasMufflerReplancement = value; propertyChanged(); }
        }

        private bool hasTireRotation;
        public bool HasTireRotation
        {
            get { return hasTireRotation; }
            set { hasTireRotation = value; propertyChanged(); }
        }

        private decimal MiscCharges()
        {
            decimal charges = 0m;
            charges += HasInspection ? InspectionPrice : 0;
            charges += HasMufflerReplancement ? MufflerReplancementPrice : 0;
            charges += HasTireRotation ? TireRotationPrice : 0;
            return charges;
        }
        #endregion

        #region OtherCharges
        public string LaborPriceContent
        {
            get { return $"({LaborPerHourPrice:c}/H)"; }
        }

        private decimal? partsCharge;
        public decimal? PartsCharge
        {
            get { return partsCharge; }
            set { partsCharge = value; propertyChanged(); }
        }

        private float? laborHours;
        public float? LaborHours
        {
            get { return laborHours; }
            set { laborHours = value; propertyChanged(); }
        }

        private decimal OtherCharges()
        {
            decimal charges = 0m;
            charges += PartsCharge ?? 0;
            charges += (decimal)(LaborHours ?? 0) * LaborPerHourPrice;
            return charges;
        }
        #endregion

        #region TaxCharges
        private decimal taxValue;
        public decimal TaxValue
        {
            get { return taxValue; }
            set { taxValue = value; propertyChanged(); }
        }

        private decimal TaxCharges()
        {
            return (PartsCharge ?? 0) * TaxPercentage;
        }
        #endregion

        #region TotalCharges
        private decimal totalValue;
        public decimal TotalValue
        {
            get { return totalValue; }
            set { totalValue = value; propertyChanged(); }
        }

        private decimal TotalCharges()
        {
            decimal charges = 0m;
            charges += OilLubeCharges();
            charges += FlushCharges();
            charges += MiscCharges();
            charges += OtherCharges();
            charges += TaxCharges();
            return charges;
        }
        #endregion

        public void Calc()
        {
            TaxValue = TaxCharges();
            TotalValue = TotalCharges();
        }

        #region Clear
        public void Clear()
        {
            ClearOilLube();
            ClearFlushes();
            ClearMisc();
            ClearOther();
            ClearTaxAndTotal();
        }

        public void ClearOilLube()
        {
            HasOilChange = false;
            HasLubeJob = false;
        }
        public void ClearFlushes()
        {
            HasRadiatorFlush = false;
            HasTransmissionFlush = false;
        }
        public void ClearMisc()
        {
            HasInspection = false;
            HasMufflerReplancement = false;
            HasTireRotation = false;
        }
        public void ClearOther()
        {
            PartsCharge = null;
            LaborHours = null;
        }
        public void ClearTaxAndTotal()
        {
            Calc();
        }
        #endregion

        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;

        private void propertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
