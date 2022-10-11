namespace tdd_GunService_Practice;

public class GunService{
	private int _currentAmmoCount;
	private int MaxAmmoCount{ get; }

	public GunService(int maxAmmoCount){
		_currentAmmoCount = maxAmmoCount;
		MaxAmmoCount = maxAmmoCount;
	}

	public void Fire(){
		if(_currentAmmoCount < 1){
			OnFire?.Invoke(_currentAmmoCount);
			OnNoAmmo?.Invoke();
		}
		else{
			_currentAmmoCount -= 1;
			OnFire?.Invoke(_currentAmmoCount);
		}
	}

	public Action<int>? OnFire{ get; set; }
	public Action? OnNoAmmo{ get; set; }
	public Action<int>? OnReload{ get; set; }

	public void Reload(){
		_currentAmmoCount = MaxAmmoCount;
		OnReload?.Invoke(MaxAmmoCount);
	}
}