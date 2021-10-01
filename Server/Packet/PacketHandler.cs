﻿using Server;
using ServerCore;
using System;
using System.Collections.Generic;
using System.Text;

class PacketHandler
{
	public static void C_LeaveGameHandler(PacketSession session, IPacket packet)
	{
		ClientSession clientSession = session as ClientSession;

		if (clientSession.Room == null)
			return;

		GameRoom room = clientSession.Room;
		room.Push(
			() => room.Leave(clientSession)
		); 
	}

	public static void C_MoveHandler(PacketSession session, IPacket packet)
    {
		C_Move movePacket = packet as C_Move;
		ClientSession clientSession = session as ClientSession;

		if (clientSession.Room == null)
			return;

        Console.WriteLine($"{movePacket.posX}, {movePacket.posY}, {movePacket.posZ}");
		GameRoom room = clientSession.Room;
		room.Push(
			() => room.Move(clientSession, movePacket)
		);
	}
	public static void C_EnterHandler(PacketSession session, IPacket packet)
	{
		
		C_Enter enterPacket = packet as C_Enter;
		ClientSession clientSession = session as ClientSession;

				
		GameRoom room = clientSession.Room;
		room.Push(
			() => room.EnterRoom(clientSession, enterPacket)
		);
	}
	public static void C_DestroyItemHandler(PacketSession session, IPacket packet)
	{

		C_DestroyItem destroyItem = packet as C_DestroyItem;
		ClientSession clientSession = session as ClientSession;


		GameRoom room = clientSession.Room;
		room.Push(
			() => room.DestroyItem(clientSession, destroyItem)
		);
	}
	public static void C_GameOverHandler(PacketSession session, IPacket packet)
	{

		C_GameOver enterPacket = packet as C_GameOver;
		ClientSession clientSession = session as ClientSession;


	}
	public static void C_DropItemHandler(PacketSession session, IPacket packet)
	{

		C_DropItem enterPacket = packet as C_DropItem;
		ClientSession clientSession = session as ClientSession;



	}
}
