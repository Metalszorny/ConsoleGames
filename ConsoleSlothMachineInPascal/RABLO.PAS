program felkaru_rablo;

uses crt;

var
	{ The first fruit. }
	firstFruit : integer;
	{ The second fruit. }
	secondFruit : integer;
	{ The third fruit. }
	thirdFruit : integer;
	{ The money variable. }
	money : integer;
	{ The user input variable. }
	input : string;
begin
	{ The text's background color. }
	textbackground(13);
	{ The text's color. }
	textcolor(black);
	{ Set the money. }
	money := 500;
	
	{ Exit if the user request's it or the money is gone. }
	repeat
		{ Use random. }
		randomize;
		{ Clear the screen. }
		clrscr;
		
		{ Generate the first fruit. }
		firstFruit := random(3) + 1;
		{ The first fruit's position. }
		gotoxy(20, 12);
		
		if firstFruit = 1 then
			writeln('alma');
		else if firstFruit = 2 then
			writeln('szilva');
		else if firstFruit = 3 then
			writeln('cseresznye');
		
		{ Generate the second fruit. }
		secondFruit := random(3) + 1;
		{ The second fruit's position. }
		gotoxy(35, 12);
		
		if secondFruit = 1 then
			writeln('alma');
		else if secondFruit = 2 then
			writeln('szilva');
		else if secondFruit = 3 then
			writeln('cseresznye');
		
		{ Generate the third fruit. }
		thirdFruit := random(3) + 1;
		{ The third fruit's position. }
		gotoxy(50, 12);
		
		if thirdFruit = 1 then
			writeln('alma');
		else if thirdFruit = 2 then
			writeln('szilva');
		else if thirdFruit = 3 then
			writeln('cseresznye');
		
		{ The exit text's position. }
		gotoxy(10, 5);
		{ The exit text. }
		writeln('Kil‚p‚s: Q');
		
		{ The money text's position. }
		gotoxy(25, 20);
		{ The money text. }
		writeln('P‚nzed:');
		
		{ The money value's position. }
		gotoxy(35, 20);
		{ Subtract the bet from the money. }
		money := money - 30;
		{ The money value. }
		writeln(money);
		
		{ The currency text's position. }
		gotoxy(38, 20);
		{ The currency text. }
		writeln('Ft');
		
		{ The iteration outcome's text position. }
		gotoxy(35, 25);
		
		if (firstFruit = secondFruit) and (secondFruit = thirdFruit) then
		begin
			{ Winning scenario for the iteration. }
			writeln('nyert‚l!');
			{ Add the winning to the money. }
			money := money + 100;
		end;
		
		if money <= 0 then
			{ Loosing scenario for the game. }
			writeln('vesztett‚l!');
		
		{ Wait for the user's input. }
		readln(input);
	until (input = 'q') or (money <= 0);
end.