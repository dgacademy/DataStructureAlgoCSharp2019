using System;

class MainClass {
  public static void Main (string[] args) {
    // Action<object> print = Console.WriteLine;

    Knight knight = new Knight();
    knight.level = 6;
    knight.rarity = UnitCard.Rarity.Common;
    knight.cardType = UnitCard.CardType.Troop;
    knight.description = "터프한 근접 전사입니다...";
    knight.elixerCost = 3;
    knight.health = 960;
    knight.damage = 120;
    knight.hitSpeed = 1.1;
    knight.damagePerSecond = 109;
    knight.target = UnitCard.Target.Ground;
    knight.range = UnitCard.Range.Melee;
    knight.deployTime = 1;
    knight.currentLevelupPoint = 18;
  }
}

// https://clashroyale.fandom.com/wiki/Cards

public class UnitCard {
  public enum CardType { Troop, Spell, Building }
  public enum Rarity { Common, Rare, Epic, Legendary };
  public enum Target { Ground, Air, GroundAir };
  public enum Range { Melee };

  public int level;
  public Rarity rarity;
  public CardType cardType;
  public string description;
  public int elixerCost;
  public int deployTime;
  public Target target;
  public int currentLevelupPoint;  
}

public class TroopCard : UnitCard {
  public int health;
  public int damage;
  public double hitSpeed;
  public int damagePerSecond;
  public int speed;
  public Range range;
}

public class BuildingCard : UnitCard {
  public int health;
  public int damage;
  public double hitSpeed;
  public int damagePerSecond;
  public Range range;
}

public class SpellCard : UnitCard {
  public int damage;
  public double radius;
  public int crownTowerDamage;
}

// https://clashroyale.fandom.com/wiki/Knight
public class Knight : TroopCard {

}

public class Tesla : BuildingCard {

}

public class Lightning : SpellCard {

}