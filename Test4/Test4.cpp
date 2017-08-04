// Test4.cpp : �R���\�[�� �A�v���P�[�V�����̃G���g�� �|�C���g���`���܂��B
//

#include "stdafx.h"

#include "stdint.h"

struct test_class{
public:
	uint16_t descriptor_index;
	uint16_t localized_description;
	uint64_t mac_address;
	uint16_t interface_flags;
	uint64_t clock_identity;
	uint8_t priority1;
	uint8_t clock_class;
	uint16_t offset_scaled_log_variance;
	uint8_t clock_accuracy;
	uint8_t priority2;
	uint8_t domain_number;
	int8_t log_sync_interval;
	int8_t log_announce_interval;
	int8_t log_pdelay_interval;
	uint16_t port_number;
};

int main()
{
	test_class * tmp = new test_class;

	tmp->descriptor_index = 0;
	tmp->localized_description = 65535;
	tmp->mac_address = 0x22970405b7;
	tmp->interface_flags = 0x7;
	tmp->clock_identity = 0x2297fffe0405b7;
	tmp->priority1 = 0;
	tmp->clock_class = 1;
	tmp->offset_scaled_log_variance = 17258;
	tmp->clock_accuracy = 32;
	tmp->priority2 = 248;
	tmp->domain_number = 0;
	tmp->log_sync_interval = -3;
	tmp->log_announce_interval = 0;
	tmp->log_pdelay_interval = 0;
	tmp->port_number = 1;

	delete tmp;

    return 0;
}

