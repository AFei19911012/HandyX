using GalaSoft.MvvmLight;

namespace GifX.ViewModel
{
    ///
    /// ----------------------------------------------------------------
    /// Copyright @CoderMan/CoderMan1012 2022 All rights reserved
    /// Author      : CoderMan/CoderMan1012
    /// Created Time: 2022/10/19 23:45:31
    /// Description :
    /// ------------------------------------------------------
    /// Version      Modified Time              Modified By                               Modified Content
    /// V1.0.0.0     2022/10/19 23:45:31    CoderMan/CoderMan1012                 
    ///
    public class WaitingWindowViewModel : ViewModelBase
    {
        private int currentValue;
        public int CurrentValue
        {
            get => currentValue;
            set => Set(ref currentValue, value);
        }

        private int maxVaule;
        public int MaxVaule
        {
            get => maxVaule;
            set => Set(ref maxVaule, value);
        }

        private bool closeVisible;
        public bool CloseVisible
        {
            get => closeVisible;
            set => Set(ref closeVisible, value);
        }
    }
}