namespace tdd_GunService_Practice;

public class GunService{
	private int _currentAmmoCount = 0;

	public GunService(int maxAmmoCount){
		_currentAmmoCount = maxAmmoCount;
	}
	public void Fire(){
		if(_currentAmmoCount < 1){
			OnFire?.Invoke(_currentAmmoCount);
			OnNoAmmo?.Invoke();
			return;
		}
		
		_currentAmmoCount -= 1;
		OnFire?.Invoke(_currentAmmoCount);
	}

	public Action<int> OnFire{ get; set; }
	public Action OnNoAmmo{ get; set; }
}