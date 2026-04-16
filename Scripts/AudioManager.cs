using Godot;
using System;

public partial class AudioManager : Node
{
	public static AudioManager Instance;

	//Main menu songs
	[Export] private AudioStreamPlayer MainMenuSong;
	[Export] private AudioStreamPlayer MainMenuSongLoop;

	//Level 1-3 songs
	[Export] private AudioStreamPlayer EarlyLevelSong;
	[Export] private AudioStreamPlayer EarlyLevelSongLoop;

	//Level 4-6 songs
	[Export] private AudioStreamPlayer LateLevelSong;
	[Export] private AudioStreamPlayer LateLevelSongLoop;

	//Endings songs
	[Export] private AudioStreamPlayer GoodEndingSong;
	[Export] private AudioStreamPlayer BadEndingSong;
	[Export] private AudioStreamPlayer MidEndingSong;

 	//UI Sfx
	[Export] private AudioStreamPlayer UIClick;
	[Export] private AudioStreamPlayer UIHover;
	[Export] private AudioStreamPlayer UIReturn;

	//Collectibles SFX
	[Export] private AudioStreamPlayer PortalSFX;
	[Export] private AudioStreamPlayer CollectToy;

    public override void _Ready()
    {
        Instance = this;
    }


    // Função de tocar a música do menu

	public void PlayMenuSong()
	{
		if(MainMenuSong.Playing || MainMenuSongLoop.Playing)
			return;
			
		MainMenuSong.Play();
	}

	public void _on_main_menu_song_finished()
	{
		MainMenuSongLoop.Play();
	}

	public void _on_main_menu_song_loop_finished()
	{
		MainMenuSongLoop.Play();
	}

	//Função de tocar a música inicial

	public void PlayEarlyLevelSong()
	{
		if(EarlyLevelSong.Playing || EarlyLevelSongLoop.Playing)
			return;
		EarlyLevelSong.Play();
	}

	public void _on_early_level_song_finished()
	{
		EarlyLevelSongLoop.Play();
	}	

	public void _on_early_level_song_loop_finished()
	{
		EarlyLevelSongLoop.Play();
	}

	//Função de tocar a música final

	public void PlayLateLevelSong()
	{
		if(LateLevelSong.Playing || LateLevelSongLoop.Playing)
			return;		
		LateLevelSong.Play();
	}

	public void _on_late_level_song_finished()
	{
		LateLevelSongLoop.Play();
	}

	public void _on_late_level_song_loop_finished()
	{
		LateLevelSongLoop.Play();
	}

	//Função de tocar as músicas dos finais

	public void PlayBadEndingSong()
	{
		BadEndingSong.Play();
	}

	public void PlayGoodEndingSong()
	{
		GoodEndingSong.Play();
	}

	//Toca os SFX da UI

	public void PlayUIClick()
	{
		UIClick.Play();
	}

	public void PlayUIHover()
	{
		UIHover.Play();
	}

	public void PlayUIReturn()
	{
		UIReturn.Play();
	}

	//Toca SFX de alguns interagíveis

	public void PlayCollectToy()
	{
		CollectToy.Play();
	}

	public void PlayPortalSFX()
	{
		PortalSFX.Play();
	}

	//Função de parar tudo

	public void StopAll()
    {
        MainMenuSong.Stop();
        MainMenuSongLoop.Stop();
        EarlyLevelSong.Stop();
        EarlyLevelSongLoop.Stop();
        LateLevelSong.Stop();
        LateLevelSongLoop.Stop();
		GoodEndingSong.Stop();
		BadEndingSong.Stop();
	}

}
