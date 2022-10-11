using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace tdd_GunService_Practice;

[SuppressMessage("Assertion",
	"NUnit2005:Consider using Assert.That(actual, Is.EqualTo(expected)) instead of Assert.AreEqual(expected, actual)")]
public class GunServiceTests{
	private GunService _gunService;

	[SetUp]
	public void Setup(){
		_gunService = new GunService(7);
	}

	private void SetAmmoCount(int ammoCount){
		_gunService = new GunService(ammoCount);
	}

	private int ReturnFiredBulletCount(){
		var returnBullet = 0;

		void TestAction(int amount){
			returnBullet = amount;
		}

		_gunService.OnFire += TestAction;
		_gunService.Fire();
		return returnBullet;
	}

	private void MultiFire(int count){
		for(int i = 0; i < count; i++){
			_gunService.Fire();
		}
	}

	[Test]
	public void fire_when_7_bullet_then_should_return_6_bullet(){
		var returnBullet = ReturnFiredBulletCount();
		Assert.AreEqual(6, returnBullet);
	}

	[Test]
	public void fire_when_0_bullet_then_should_receive_noAmmo_event(){
		SetAmmoCount(0);
		var actionIsInvoked = false;

		void TestAction(){
			actionIsInvoked = true;
		}

		_gunService.OnNoAmmo += TestAction;
		_gunService.Fire();
		Assert.IsTrue(actionIsInvoked);
	}

	[Test]
	public void fire_when_0_bullet_then_should_return_0_bullet(){
		SetAmmoCount(0);
		var returnBullet = ReturnFiredBulletCount();
		Assert.AreEqual(0, returnBullet);
	}

	[Test]
	public void reload_when_5_bullet_then_should_return_7_bullet(){
		var ammoCount = 0;

		void TestAction(int amount){
			ammoCount = amount;
		}

		_gunService.OnReload += TestAction;
		MultiFire(2);
		_gunService.Reload();
		Assert.AreEqual(7, ammoCount);
	}

	[Test]
	public void multiFire_when_7_bullet_and_8_times_fire_should_receive_no_ammo_event(){
		var returnBullet = 0;
		var noAmmoEventInvokeTimes = 0;
		void NoAmmoTestAction(){
			noAmmoEventInvokeTimes++;
		}

		void FireTestAction(int amount){
			returnBullet = amount;
		}

		_gunService.OnFire += FireTestAction;
		_gunService.OnNoAmmo += NoAmmoTestAction;
		MultiFire(8);
		Assert.AreEqual(0, returnBullet);
		Assert.AreEqual(1 , noAmmoEventInvokeTimes);
	}
}