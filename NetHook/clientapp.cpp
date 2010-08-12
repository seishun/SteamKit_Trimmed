

#include <winsock2.h>
#include <windows.h>

#include "clientapp.h"

#include "logger.h"
#include "udpconnection.h"
#include "wshooks.h"
#include "crypto.h"
#include "msgmanager.h"

#include "interface.h"


#define NO_STEAM
#define STEAMTYPES_H

typedef void *unknown_ret;
#include "usercommon.h"
#include "ESteamError.h"
#include "isteamclient009.h"
#include "isteamgameserver010.h"
#include "ISteamUser004.h"



// define our clientapp entry point
//CLIENTAPP( main );


CLogger *g_Logger = NULL;
CUDPConnection *g_udpConnection = NULL;


typedef bool ( STEAM_CALL *Steam_BGetCallback )( HSteamPipe hSteamPipe, CallbackMsg_t *pCallbackMsg );
typedef void ( STEAM_CALL *Steam_FreeLastCallback )( HSteamPipe hSteamPipe );

Steam_BGetCallback GetCallback;
Steam_FreeLastCallback FreeCallback;

int AnonLogin()
{
	CreateInterfaceFn factory = Sys_GetFactory( "steamclient" );

	ISteamClient009 *steamClient = (ISteamClient009 *)factory( STEAMCLIENT_INTERFACE_VERSION_009, NULL );

	HSteamPipe hPipe = 0;
	HSteamUser hUser = steamClient->CreateLocalUser( &hPipe, k_EAccountTypeAnonUser );

	ISteamGameServer010 *gameServer = (ISteamGameServer010 *)steamClient->GetISteamGameServer( hUser, hPipe, STEAMGAMESERVER_INTERFACE_VERSION_010 );
	ISteamUser004 *steamUser = (ISteamUser004 *)steamClient->GetISteamUser( hUser, hPipe, STEAMUSER_INTERFACE_VERSION_004 );

	CSteamID steamId;
	steamId.CreateBlankAnonUserLogon( k_EUniversePublic );

	steamUser->LogOn( steamId );

	//gameServer->LogOn();


	CallbackMsg_t callBack;

	while ( true )
	{
		if ( GetCallback( hPipe, &callBack ) )
		{
			FreeCallback( hPipe );

			// session key is recreated here, so lets allow it
			if ( callBack.m_iCallback == SteamServerConnectFailure_t::k_iCallback )
				g_Crypto->CanReset();

			g_Logger->LogConsole( "Got callback %d\n", callBack.m_iCallback );

		}

		Sleep( 10 );
	}

	return 1;
}



int main( int argc, char **argv )
{

	//AllocConsole();

	g_Logger = new CLogger( argv[ 0 ] );

	g_udpConnection = new CUDPConnection();

	Detour_WSAStartup->Attach();

	HMODULE steamClient = LoadLibrary( "steamclient.dll" );

	GetCallback = (Steam_BGetCallback)GetProcAddress( steamClient, "Steam_BGetCallback" );
	FreeCallback = (Steam_FreeLastCallback)GetProcAddress( steamClient, "Steam_FreeLastCallback" );


#if 0
	// load the real client app
	HMODULE steamUI = LoadLibrary( "SteamUI.dll" );
	if ( !steamUI )
	{
		MessageBox( HWND_DESKTOP, "Unable to load SteamUI.", "Oops!", MB_OK );
		return -1;
	}

	SteamDllMainFn realSteamMain = ( SteamDllMainFn )GetProcAddress( steamUI, "SteamDllMain" );
	if ( !realSteamMain )
	{
		MessageBox( HWND_DESKTOP, "Unable to find Steam entrypoint.", "Oops!", MB_OK );
		return -1;
	}

	int ret = realSteamMain( argc, argv );

	FreeLibrary( steamUI );
#endif


	int ret = AnonLogin();

	FreeLibrary( steamClient );

	
	// udp
	Detour_recvfrom->Detach(); 
	Detour_WSASendTo->Detach();

	// tcp
	Detour_WSARecv->Detach();
	Detour_WSASend->Detach();

	Detour_WSAStartup->Detach();


	if ( g_Crypto )
		delete g_Crypto; // cleanup crypto hooks

	delete g_udpConnection;
	delete g_Logger;

	return ret;
}
