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
	[Test]
	public void fire_when_7_bullet_then_should_return_6_bullet(){
		var gunService = _gunService;
		var returnBullet = 0;

		void TestAction(int amount){
			returnBullet = amount;
		}

		gunService.OnFire += TestAction;
		gunService.Fire();
		Assert.AreEqual(6, returnBullet);
	}
	
}