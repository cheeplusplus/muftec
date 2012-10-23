( Sample program for testing simple Muftec stuff )

: btos ( i -- s )
	(Converts a 'boolean' to a string)
	if "true" else "false" then
;

: add
	1 1 + "test!" abort
;

: main
	add dup print 2 = dup btos print
;