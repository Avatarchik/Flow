public class LevelPath
{
	private const string starting_folder = "Assets/Resources/Puzzle Setups/";
	private string levels;
	private string sublevels;
	private string level_name;
	private const string leveldata = "LevelData.txt";

	public LevelPath()
	{
		levels = string.Empty;
		sublevels = string.Empty;
		level_name = string.Empty;
	}

	public LevelPath(string level, string sublevel, string name)
	{
		levels = level;
		sublevels = sublevel;
		level_name = name;
	}

	public string Create()
	{
		return starting_folder + levels + sublevels + level_name;
	}

	public void Reset()
	{
		levels = string.Empty;
		sublevels = string.Empty;
		level_name = string.Empty;
	}

	public string Level
	{
		get { return levels; }
		set { levels = value; }
	}

	public string SubLevel
	{
		get { return sublevels; }
		set { sublevels = value; }
	}

	public string LevelName
	{
		get { return level_name; }
		set { level_name = value; }
	}

	public string CreateLevelDataPath()
	{
		return starting_folder + levels + sublevels + leveldata;
	}
}