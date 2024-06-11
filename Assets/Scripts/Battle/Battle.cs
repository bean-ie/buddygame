using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle
{
    List<BattleUnit> units = new List<BattleUnit>();
    public List<FUAUsage> fuaQueue = new List<FUAUsage>();
    int currentTurn;

    public Battle(EncounterSO encounter)
    {
        if (encounter == null) return;
        for (int i = 0; i < GameManager.instance.teamManager.teamUnits.Length; i++)
        {
            units.Add(GameManager.instance.teamManager.teamUnits[i]);
        }
        for (int i = 0; i < encounter.enemies.Length; i++)
        {
            units.Add(new EnemyUnit(encounter.enemies[i]));
        }
    }

    /*public void SortUnitsBySpeed()
    {
        units.Sort((x, y) => y.stats.speed.CompareTo(x.stats.speed));
        for (int i = 0; i < units.Count; i++)
        {
            Debug.Log(units[i].unitName + (units[i].isEnemy ? " - enemy" : " - ally"));
        }
    }*/

    public void EndTurn()
    {
        if (currentTurn == units.Count - 1)
        {
            currentTurn = 0;
        } else
        {
            currentTurn++;
        }
    }

    public BattleUnit GetCurrentActingUnit()
    {
        return units[currentTurn];
    }

    public BattleUnit GetUnitAt(int index)
    {
        return units[index];
    }

    public int GetIndexOf(BattleUnit unit)
    {
        for (int i = 0; i < units.Count; i++)
        {
            if (units[i] == unit)
            {
                return i;
            }
        }
        return -1;
    }

    public int EnemyCount()
    {
        int count = 0;
        foreach (BattleUnit unit in units)
        {
            if (unit.isEnemy) count++;
        }
        return count;
    }

    public int AliveEnemyCount()
    {
        int count = 0;
        foreach (BattleUnit unit in units)
        {
            if (unit.isEnemy && !unit.isDead) count++;
        }
        return count;
    }

    public List<int> GetAliveEnemiesIndex()
    {
        List<int> indecies = new List<int>();
        for (int i = 0; i < units.Count; i++)
        {
            if (units[i].isEnemy && !units[i].isDead)
            {
                indecies.Add(i);
            }
        }
        return indecies;
    }

    public List<BattleUnit> GetAllUnits()
    {
        return units;
    }

    public int GetCurrentActingUnitIndex()
    {
        return currentTurn;
    }

    public void AddFuaToQueue(FUAUsage fua, bool addFirst = false)
    {
        if (addFirst)
            fuaQueue.Insert(0, fua);
        else
            fuaQueue.Add(fua);
    }
}
