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

	[Test]
	public void fire_when_7_bullet_then_should_return_6_bullet(){
		var returnBullet = 0;

		void TestAction(int amount){
			returnBullet = amount;
		}

		_gunService.OnFire += TestAction;
		_gunService.Fire();
		Assert.AreEqual(6, returnBullet);
	}
	[Test]
	public void fire_when_0_bullet_then_should_sand_noAmmo_event(){
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
		var returnBullet = 0;
		void TestAction(int amount){
			returnBullet = amount;
		}

		_gunService.OnFire += TestAction;
		_gunService.Fire();
		Assert.AreEqual(0, returnBullet);
	}
}