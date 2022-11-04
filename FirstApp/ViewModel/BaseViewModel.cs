using System.Runtime.CompilerServices;

namespace FirstApp.ViewModel
{
    public abstract class BaseViewModel: ExtendedBindableObject
    {
        #region Override methods
        protected override bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            var result = base.SetProperty(ref storage, value, propertyName);
            if (result && !string.IsNullOrWhiteSpace(propertyName))
            {
                
            }
            return result;
        }
        #endregion
    }
}