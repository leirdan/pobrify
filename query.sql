-- SELECIONAR CADA MÚSICA DE CADA PLAYLIST COM INFORMAÇÕES DE QUEM FEZ A MÚSICA
select 
	playlistid as id_playlist,
	p.title, albumid as id_album,
	a.Name as artist, s.title,
	u.id as id_user, u.name
	from playlistsong ps
	inner join playlist p
		on p.id = ps.playlistid
	inner join songs s
		on s.id = ps.songid
	inner join users u
		on u.id = p.userid
	inner join artists a
		on a.Id = s.ArtistId
	order by s.title asc

-- SELECIONAR A PLAYLIST QUE CADA USUÁRIO CRIOU
/*
select 
	users.id as id_user, name, title, length 
	from users 
	inner join playlist p 
		on p.UserId = users.id

-- SELECIONAR TODAS AS MÚSICAS QUE PERTENCEM A UM ARTISTA
select 
	songs.id as id_song, title, artists.id as id_artist, name 
	from songs 
	inner join artists 
		on artists.id = songs.artistid 
	order by title asc
	*/