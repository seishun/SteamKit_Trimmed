
#ifndef CRYPTO_H_
#define CRYPTO_H_
#ifdef _WIN32
#pragma once
#endif


#define _WINSOCKAPI_ // god damn winsock headers
#include "csimpledetour.h"

#include "steam/steamtypes.h"


class CCrypto
{

public:
	CCrypto();
	~CCrypto();


	bool SymmetricEncrypt( const uint8 *pubPlaintextData, uint32 cubPlaintextData, uint8 *pubEncryptedData, uint32 *pcubEncryptedData, uint32 cubKey );
	bool SymmetricDecrypt( const uint8 *pubEncryptedData, uint32 cubEncryptedData, uint8 *pubPlaintextData, uint32 *pcubPlaintextData, const uint8 *pubKey, uint32 cubKey );

	void GenerateRandomBlock( uint8 *pubDest );

	void CanReset() { m_bCanReset = true; }


	uint8 *GetSessionKey() { return m_rghSessionKey; }

private:
	uint8 m_rghSessionKey[ 32 ];

	bool m_bSessionGen;
	bool m_bCanReset;

};


extern CCrypto *g_Crypto;


#endif // !CRYPTO_H_