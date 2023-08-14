using System;
public class LevelSystem
{
    public event Action OnExperienceChanged;
    public event Action OnLevelChanged;
    private int[] experiencePerLevel;
    private int level;
    private int experience;
    public LevelSystem(int[] experiencePerLevel)
    {
        level = 0;
        experience = 0;
        this.experiencePerLevel = experiencePerLevel;
    }
    public void AddExperience(int amount)
    {
        if (!IsMaxLevel())
        {
            experience += amount;
            while (!IsMaxLevel() && experience >= GetExperienceNextLevel(level))
            {
                experience -= GetExperienceNextLevel(level);
                level++;
                OnLevelChanged?.Invoke();
            }
            OnExperienceChanged?.Invoke();
        }
    }
    public int GetLevel()
    {
        return level;
    }
    public float GetExperienceNormalized()
    {
        if (IsMaxLevel())
            return 1f;
        else
            return (float)experience / GetExperienceNextLevel(level);
    }
    public int GetExperience()
    {
        return experience;
    }
    public int GetExperienceNextLevel(int level)
    {
        if (level < experiencePerLevel.Length)
            return experiencePerLevel[level];
        else
            return 100;
    }
    public bool IsMaxLevel()
    {
        return IsMaxLevel(level);
    }
    public bool IsMaxLevel(int level)
    {
        return level == experiencePerLevel.Length - 1;
    }
    public void Clear()
    {
        level = 0;
        experience = 0;
    }
}
