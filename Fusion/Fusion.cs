using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfinityScript;

namespace Fusion
{
    public unsafe class Fusion : BaseScript
    { 
        private int[] gunOffsets = new int[18];
        private int[] camoOffsets = new int[18];
        private int[] attachOffsets = new int[18];
        private static int addressOffset = 0x38A4;
        private static int weaponOffset = 0;
        public Fusion()
        {
            gunOffsets[0] = 0x1AC2370;
            gunOffsets[1] = gunOffsets[0] + addressOffset;
            gunOffsets[2] = gunOffsets[1] + addressOffset;
            gunOffsets[3] = gunOffsets[2] + addressOffset;
            gunOffsets[4] = gunOffsets[3] + addressOffset;
            gunOffsets[5] = gunOffsets[4] + addressOffset;
            gunOffsets[6] = gunOffsets[5] + addressOffset;
            gunOffsets[7] = gunOffsets[6] + addressOffset;
            gunOffsets[8] = gunOffsets[7] + addressOffset;
            gunOffsets[9] = gunOffsets[8] + addressOffset;
            gunOffsets[10] = gunOffsets[9] + addressOffset;
            gunOffsets[11] = gunOffsets[10] + addressOffset;
            gunOffsets[12] = gunOffsets[11] + addressOffset;
            gunOffsets[13] = gunOffsets[12] + addressOffset;
            gunOffsets[14] = gunOffsets[13] + addressOffset;
            gunOffsets[15] = gunOffsets[14] + addressOffset;
            gunOffsets[16] = gunOffsets[15] + addressOffset;
            gunOffsets[17] = gunOffsets[16] + addressOffset;
            camoOffsets[0] = 0x1AC2371;
            camoOffsets[1] = camoOffsets[0] + addressOffset;
            camoOffsets[2] = camoOffsets[1] + addressOffset;
            camoOffsets[3] = camoOffsets[2] + addressOffset;
            camoOffsets[4] = camoOffsets[3] + addressOffset;
            camoOffsets[5] = camoOffsets[4] + addressOffset;
            camoOffsets[6] = camoOffsets[5] + addressOffset;
            camoOffsets[7] = camoOffsets[6] + addressOffset;
            camoOffsets[8] = camoOffsets[7] + addressOffset;
            camoOffsets[9] = camoOffsets[8] + addressOffset;
            camoOffsets[10] = camoOffsets[9] + addressOffset;
            camoOffsets[11] = camoOffsets[10] + addressOffset;
            camoOffsets[12] = camoOffsets[11] + addressOffset;
            camoOffsets[13] = camoOffsets[12] + addressOffset;
            camoOffsets[14] = camoOffsets[13] + addressOffset;
            camoOffsets[15] = camoOffsets[14] + addressOffset;
            camoOffsets[16] = camoOffsets[15] + addressOffset;
            camoOffsets[17] = camoOffsets[16] + addressOffset;
            attachOffsets[0] = 0x1AC2372;
            attachOffsets[1] = attachOffsets[0] + addressOffset;
            attachOffsets[2] = attachOffsets[1] + addressOffset;
            attachOffsets[3] = attachOffsets[2] + addressOffset;
            attachOffsets[4] = attachOffsets[3] + addressOffset;
            attachOffsets[5] = attachOffsets[4] + addressOffset;
            attachOffsets[6] = attachOffsets[5] + addressOffset;
            attachOffsets[7] = attachOffsets[6] + addressOffset;
            attachOffsets[8] = attachOffsets[7] + addressOffset;
            attachOffsets[9] = attachOffsets[8] + addressOffset;
            attachOffsets[10] = attachOffsets[9] + addressOffset;
            attachOffsets[11] = attachOffsets[10] + addressOffset;
            attachOffsets[12] = attachOffsets[11] + addressOffset;
            attachOffsets[13] = attachOffsets[12] + addressOffset;
            attachOffsets[14] = attachOffsets[13] + addressOffset;
            attachOffsets[15] = attachOffsets[14] + addressOffset;
            attachOffsets[16] = attachOffsets[15] + addressOffset;
            attachOffsets[17] = attachOffsets[16] + addressOffset;
            PlayerConnected += OnPlayerConnected;

            GSCFunctions.SetDvarIfUninitialized("scr_fusion_weaponOffset", 0);
            weaponOffset = GSCFunctions.GetDvarInt("scr_fusion_weaponOffset");
        }
        void OnPlayerConnected(Entity player)
        {
            player.OnNotify("joined_team", entity =>
            {
                player.CloseInGameMenu();
                player.Notify("menuresponse", "changeclass", "axis_recipe1");
            });
            player.SpawnedPlayer += () => OnPlayerSpawned(player);
        }
        void OnPlayerSpawned(Entity player)
        {
            Fuse(player, player.EntRef);
        }
        public void Fuse(Entity player, int ID)
        {
            int? fuses = new Random().Next(40);
            switch (fuses)
            {
                case 0:
                    player.IPrintLnBold("You got the SPAS-118A");
                    player.TakeAllWeapons();
                    player.GiveWeapon("iw5_l96a1_mp");
                    AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_l96a1_mp");
                        });
                    AfterDelay(400, () =>
                        {
                            player.TakeAllWeapons();
                            *(int*)gunOffsets[ID] = weaponOffset + 52;
                            *(int*)camoOffsets[ID] = 15;
                            AfterDelay(250, () =>
                            {
                                player.SwitchToWeaponImmediate("iw5_spas12_mp_camo15");
                                player.GiveMaxAmmo("iw5_spas12_mp_camo15");
                                player.SetWeaponAmmoClip("iw5_spas12_mp_camo15", 8);
                            });
                        });
                    break;
                case 1:
                    player.IPrintLnBold("You got the F2000 ACOG Scope");
                    player.TakeAllWeapons();
                    player.GiveWeapon("alt_uav_strike_marker_mp");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("alt_uav_strike_marker_mp");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 18;
                        *(int*)camoOffsets[ID] = 31;
                        *(int*)attachOffsets[ID] = 2;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_mp5_mp_acogsmg_rof_camo15");
                            player.GiveMaxAmmo("iw5_mp5_mp_acogsmg_rof_camo15");
                            player.SetWeaponAmmoClip("iw5_mp5_mp_acogsmg_rof_camo15", 30);
                        });
                    });
                    break;
                case 2:
                    player.IPrintLnBold("You got the USP .57");
                    player.TakeAllWeapons();
                    player.GiveWeapon("iw5_usp45_mp");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("iw5_usp45_mp");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 13;
                        *(int*)camoOffsets[ID] = 15;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_fnfiveseven_mp_camo15");
                            player.GiveMaxAmmo("iw5_fnfiveseven_mp_camo15");
                            player.SetWeaponAmmoClip("iw5_fnfiveseven_mp_camo15", 16);
                        });
                    });
                    break;
                case 3:
                    player.IPrintLnBold("You got the MP44 Magnum");
                    player.TakeAllWeapons();
                    player.GiveWeapon("iw5_mp412_mp");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("iw5_mp412_mp");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 6;
                        *(int*)camoOffsets[ID] = 15;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_44magnum_mp_camo15");
                            player.GiveMaxAmmo("iw5_44magnum_mp_camo15");
                            player.SetWeaponAmmoClip("iw5_44magnum_mp_camo15", 6);
                        });
                    });
                    break;
                case 4:
                    player.IPrintLnBold("You got the Desert P99");
                    player.TakeAllWeapons();
                    player.GiveWeapon("iw5_deserteagle_mp");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("iw5_deserteagle_mp");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 12;
                        *(int*)camoOffsets[ID] = 15;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_p99_mp_camo15");
                            player.GiveMaxAmmo("iw5_p99_mp_camo15");
                            player.SetWeaponAmmoClip("iw5_p99_mp_camo15", 12);
                        });
                    });
                    break;
                case 5:
                    player.IPrintLnBold("You got the Five .45");
                    player.TakeAllWeapons();
                    player.GiveWeapon("iw5_fnfiveseven_mp");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("iw5_fnfiveseven_mp");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 7;
                        *(int*)camoOffsets[ID] = 15;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_usp45_mp_camo15");
                            player.GiveMaxAmmo("iw5_usp45_mp_camo15");
                            player.SetWeaponAmmoClip("iw5_usp45_mp_camo15", 12);
                        });
                    });
                    break;
                case 6:
                    player.IPrintLnBold("You got the FMG12");
                    player.TakeAllWeapons();
                    player.GiveWeapon("iw5_fmg9_mp");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("iw5_fmg9_mp");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 47;
                        *(int*)camoOffsets[ID] = 143;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_ksg_mp_grip_camo15");
                            player.GiveMaxAmmo("iw5_ksg_mp_grip_camo15");
                            player.SetWeaponAmmoClip("iw5_ksg_mp_grip_camo15", 12);
                        });
                    });
                    break;
                case 7:
                    player.IPrintLnBold("You got the MPM-9");
                    player.TakeAllWeapons();
                    player.GiveWeapon("iw5_mp9_mp_eotechsmg");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("iw5_mp9_mp_eotechsmg");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 19;
                        *(int*)camoOffsets[ID] = 31;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_m9_mp_acogsmg_camo15");
                            player.GiveMaxAmmo("iw5_m9_mp_acogsmg_camo15");
                            player.SetWeaponAmmoClip("iw5_m9_mp_acogsmg_camo15", 32);
                        });
                    });
                    break;
                case 8:
                    player.IPrintLnBold("You got the P18");
                    player.TakeAllWeapons();
                    player.GiveWeapon("iw5_p99_mp");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("iw5_p99_mp");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 17;
                        *(int*)camoOffsets[ID] = 15;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_g18_mp_camo15");
                            player.GiveMaxAmmo("iw5_g18_mp_camo15");
                            player.SetWeaponAmmoClip("iw5_g18_mp_camo15", 20);
                        });
                    });
                    break;
                case 9:
                    player.IPrintLnBold("You got the Dragunov14");
                    player.TakeAllWeapons();
                    player.GiveWeapon("iw5_dragunov_mp");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("iw5_dragunov_mp");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 30;
                        *(int*)camoOffsets[ID] = 15;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_mk14_mp_camo15");
                            player.GiveMaxAmmo("iw5_mk14_mp_camo15");
                            player.SetWeaponAmmoClip("iw5_mk14_mp_camo15", 20);
                        });
                    });
                    break;
                case 10:
                    player.IPrintLnBold("You got the PMP9");
                    player.TakeAllWeapons();
                    player.GiveWeapon("iw5_m9_mp");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("iw5_m9_mp");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 16;
                        *(int*)camoOffsets[ID] = 31;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_mp9_mp_reflexsmg_camo15");
                            player.GiveMaxAmmo("iw5_mp9_mp_reflexsmg_camo15");
                            player.SetWeaponAmmoClip("iw5_mp9_mp_reflexsmg_camo15", 32);
                        });
                    });
                    break;
                case 11:
                    player.IPrintLnBold("You got the USAS901");
                    player.TakeAllWeapons();
                    player.GiveWeapon("iw5_usas12_mp");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("iw5_usas12_mp");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 33;
                        *(int*)camoOffsets[ID] = 47;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_cm901_mp_eotech_camo15");
                            player.GiveMaxAmmo("iw5_cm901_mp_eotech_camo15");
                            player.SetWeaponAmmoClip("iw5_cm901_mp_eotech_camo15", 30);
                        });
                    });
                    break;
                case 12:
                    player.IPrintLnBold("You got the M16A1");
                    player.TakeAllWeapons();
                    player.GiveWeapon("iw5_m16_mp_gl");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("iw5_m16_mp_gl");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 26;
                        *(int*)camoOffsets[ID] = 31;
                        *(int*)attachOffsets[ID] = 1;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_m4_mp_acog_gl_camo15");
                            player.GiveMaxAmmo("iw5_m4_mp_acog_gl_camo15");
                            player.SetWeaponAmmoClip("iw5_m4_mp_acog_gl_camo15", 30);
                        });
                    });
                    break;
                case 13:
                    player.IPrintLnBold("You got the ACR 4.5");
                    player.TakeAllWeapons();
                    player.GiveWeapon("iw5_acr_mp");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("iw5_acr_mp");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 22;
                        *(int*)camoOffsets[ID] = 15;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_ump45_mp_camo15");
                            player.GiveMaxAmmo("iw5_ump45_mp_camo15");
                            player.SetWeaponAmmoClip("iw5_ump45_mp_camo15", 32);
                        });
                    });
                    break;
                case 14:
                    player.IPrintLnBold("You got the MKSASS");
                    player.TakeAllWeapons();
                    player.GiveWeapon("iw5_mk14_mp_acog");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("iw5_mk14_mp_acog");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 44;
                        *(int*)camoOffsets[ID] = 15;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_rsass_mp_camo15");
                            player.GiveMaxAmmo("iw5_rsass_mp_camo15");
                            player.SetWeaponAmmoClip("iw5_rsass_mp_camo15", 20);
                        });
                    });
                    break;
                case 15:
                    player.IPrintLnBold("You got the USAA12");
                    player.TakeAllWeapons();
                    player.GiveWeapon("iw5_usas12_mp_reflex");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("iw5_usas12_mp_reflex");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 50;
                        *(int*)camoOffsets[ID] = 15;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_aa12_mp_camo15");
                            player.GiveMaxAmmo("iw5_aa12_mp_camo15");
                            player.SetWeaponAmmoClip("iw5_aa12_mp_camo15", 8);
                        });
                    });
                    break;
                case 16:
                    player.IPrintLnBold("You got the XM95");
                    player.TakeAllWeapons();
                    player.GiveWeapon("xm25_mp");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("xm25_mp");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 29;
                        *(int*)camoOffsets[ID] = 79;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_type95_mp_thermal_camo15");
                            player.GiveMaxAmmo("iw5_type95_mp_thermal_camo15");
                            player.SetWeaponAmmoClip("iw5_type95_mp_thermal_camo15", 30);
                        });
                    });
                    break;
                case 17:
                    player.IPrintLnBold("You got the AUG LSW");
                    player.TakeAllWeapons();
                    player.GiveWeapon("iw5_m60jugg_mp_camo06");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("iw5_m60jugg_mp_camo06");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 57;
                        *(int*)camoOffsets[ID] = 79;
                        *(int*)attachOffsets[ID] = 10;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_sa80_mp_heartbeat_silencer_thermal_camo15");
                            player.GiveMaxAmmo("iw5_sa80_mp_heartbeat_silencer_thermal_camo15");
                            player.SetWeaponAmmoClip("iw5_sa80_mp_heartbeat_silencer_thermal_camo15", 100);
                        });
                    });
                    break;
                case 18:
                    player.IPrintLnBold("You got the MW2 M16A4");
                    player.TakeAllWeapons();
                    player.GiveWeapon("gl_mp");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("gl_mp");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 25;
                        *(int*)camoOffsets[ID] = 47;
                        *(int*)attachOffsets[ID] = 10;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_m16_mp_eotech_heartbeat_silencer_camo15");
                            player.GiveMaxAmmo("iw5_m16_mp_eotech_heartbeat_silencer_camo15");
                            player.SetWeaponAmmoClip("iw5_m16_mp_eotech_heartbeat_silencer_camo15", 30);
                        });
                    });
                    break;
                case 19:
                    player.IPrintLnBold("You got the MPM79");
                    player.TakeAllWeapons();
                    player.GiveWeapon("iw5_mp7_mp_reflexsmg");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("iw5_mp7_mp_reflexsmg");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 19;
                        *(int*)camoOffsets[ID] = 63;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_m9_mp_reflexsmg_camo15");
                            player.GiveMaxAmmo("iw5_m9_mp_reflexsmg_camo15");
                            player.SetWeaponAmmoClip("iw5_m9_mp_reflexsmg_camo15", 32);
                        });
                    });
                    break;
                case 20:
                    player.IPrintLnBold("You got the PKP46");
                    player.TakeAllWeapons();
                    player.GiveWeapon("iw5_pecheneg_mp");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("iw5_pecheneg_mp");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 55;
                        *(int*)camoOffsets[ID] = 15;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_mk46_mp_camo15");
                            player.GiveMaxAmmo("iw5_mk46_mp_camo15");
                            player.SetWeaponAmmoClip("iw5_mk46_mp_camo15", 100);
                        });
                    });
                    break;
                case 21:
                    player.IPrintLnBold("You got the M4A1-L");
                    player.TakeAllWeapons();
                    player.GiveWeapon("iw5_m4_mp_gl");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("iw5_m4_mp_gl");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 31;
                        *(int*)camoOffsets[ID] = 31;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_scar_mp_acog_camo15");
                            player.GiveMaxAmmo("iw5_scar_mp_acog_camo15");
                            player.SetWeaponAmmoClip("iw5_scar_mp_acog_camo15", 30);
                        });
                    });
                    break;
                case 22:
                    player.IPrintLnBold("You got the Barrett-L");
                    player.TakeAllWeapons();
                    player.GiveWeapon("iw5_barrett_mp_acog");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("iw5_barrett_mp_acog");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 31;
                        *(int*)camoOffsets[ID] = 15;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_scar_mp_camo15");
                            player.GiveMaxAmmo("iw5_scar_mp_camo15");
                            player.SetWeaponAmmoClip("iw5_scar_mp_camo15", 30);
                        });
                    });
                    break;
                case 23:
                    player.IPrintLnBold("You got the MP901");
                    player.TakeAllWeapons();
                    player.GiveWeapon("iw5_mp5_mp_reflexsmg");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("iw5_mp5_mp_reflexsmg");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 33;
                        *(int*)camoOffsets[ID] = 63;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_cm901_mp_reflex_camo15");
                            player.GiveMaxAmmo("iw5_cm901_mp_reflex_camo15");
                            player.SetWeaponAmmoClip("iw5_cm901_mp_reflex_camo15", 30);
                        });
                    });
                    break;
                case 24:
                    player.IPrintLnBold("You got the Elbow Basher");
                    player.TakeAllWeapons();
                    player.GiveWeapon("defaultweapon_mp");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("defaultweapon_mp");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 5;
                        *(int*)camoOffsets[ID] = 15;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_riotshieldjugg_mp_camo15");
                            player.SetPerk("specialty_fastermelee", true, false);
                        });
                    });
                    break;
                case 25:
                    player.IPrintLnBold("You got the PPStriker");
                    player.TakeAllWeapons();
                    player.GiveWeapon("iw5_pp90m1_mp");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("iw5_pp90m1_mp");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 49;
                        *(int*)camoOffsets[ID] = 15;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_striker_mp_camo15");
                            player.GiveMaxAmmo("iw5_striker_mp_camo15");
                            player.SetWeaponAmmoClip("iw5_striker_mp_camo15", 12);
                        });
                    });
                    break;
                case 26:
                    player.IPrintLnBold("You got the G36-L");
                    player.TakeAllWeapons();
                    player.GiveWeapon("iw5_g36c_mp");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("iw5_g36c_mp");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 31;
                        *(int*)camoOffsets[ID] = 31;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_scar_mp_acog_camo15");
                            player.GiveMaxAmmo("iw5_scar_mp_acog_camo15");
                            player.SetWeaponAmmoClip("iw5_scar_mp_acog_camo15", 30);
                        });
                    });
                    break;
                case 27:
                    player.IPrintLnBold("You got the Scar-36");
                    player.TakeAllWeapons();
                    player.GiveWeapon("iw5_scar_mp_m320");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("iw5_scar_mp_m320");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 58;
                        *(int*)camoOffsets[ID] = 15;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_mg36_mp_camo15");
                            player.GiveMaxAmmo("iw5_mg36_mp_camo15");
                            player.SetWeaponAmmoClip("iw5_mg36_mp_camo15", 100);
                        });
                    });
                    break;
                case 28:
                    player.IPrintLnBold("You got the AS901");
                    player.TakeAllWeapons();
                    player.GiveWeapon("iw5_as50_mp_acog");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("iw5_as50_mp_acog");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 33;
                        *(int*)camoOffsets[ID] = 15;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_cm901_mp_camo15");
                            player.GiveMaxAmmo("iw5_cm901_mp_camo15");
                            player.SetWeaponAmmoClip("iw5_cm901_mp_camo15", 30);
                        });
                    });
                    break;
                case 29:
                    player.IPrintLnBold("You got the PhoneM-9");
                    player.TakeAllWeapons();
                    player.GiveWeapon("killstreak_uav_mp");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("killstreak_uav_mp");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 19;
                        *(int*)camoOffsets[ID] = 47;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_m9_mp_eotechsmg_camo15");
                            player.GiveMaxAmmo("iw5_m9_mp_eotechsmg_camo15");
                            player.SetWeaponAmmoClip("iw5_m9_mp_eotechsmg_camo15", 32);
                        });
                    });
                    break;
                case 30:
                    player.IPrintLnBold("You got the Laptop Assaulter");
                    player.TakeAllWeapons();
                    player.GiveWeapon("killstreak_predator_missile_mp");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("killstreak_predator_missile_mp");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 5;
                        *(int*)camoOffsets[ID] = 15;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_riotshieldjugg_mp_camo15");
                            player.SetPerk("specialty_fastermelee", true, false);
                        });
                    });
                    break;
                case 31:
                    player.IPrintLnBold("You got the MW2 USP .45");
                    player.TakeAllWeapons();
                    player.GiveWeapon("throwingknife_mp");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("throwingknife_mp");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 7;
                        *(int*)camoOffsets[ID] = 15;
                        *(int*)attachOffsets[ID] = 2;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_usp45_mp_silencer02_camo15");
                            player.GiveMaxAmmo("iw5_usp45_mp_silencer02_camo15");
                            player.SetWeaponAmmoClip("iw5_usp45_mp_silencer02_camo15", 12);
                        });
                    });
                    break;
                case 32:
                    player.IPrintLnBold("You got the CoD4 AK-47");
                    player.TakeAllWeapons();
                    player.GiveWeapon("bomb_site_mp");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("bomb_site_mp");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 24;
                        *(int*)camoOffsets[ID] = 15;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_ak47_mp_camo15");
                            player.GiveMaxAmmo("iw5_ak47_mp_camo15");
                            player.SetWeaponAmmoClip("iw5_ak47_mp_camo15", 30);
                        });
                    });
                    break;
                case 33:
                    player.IPrintLnBold("You got the MSRSASS");
                    player.TakeAllWeapons();
                    player.GiveWeapon("iw5_msr_mp_msrscope");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("iw5_msr_mp_msrscope");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 44;
                        *(int*)camoOffsets[ID] = 15;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_rsass_mp_camo15");
                            player.GiveMaxAmmo("iw5_rsass_mp_camo15");
                            player.SetWeaponAmmoClip("iw5_rsass_mp_camo15", 20);
                        });
                    });
                    break;
                case 34:
                    player.IPrintLnBold("You got the PortableM-9");
                    player.TakeAllWeapons();
                    player.GiveWeapon("portable_radar_mp");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("portable_radar_mp");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 19;
                        *(int*)camoOffsets[ID] = 15;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_m9_mp_camo15");
                            player.GiveMaxAmmo("iw5_m9_mp_camo15");
                            player.SetWeaponAmmoClip("iw5_m9_mp_camo15", 32);
                        });
                    });
                    break;
                case 35:
                    player.IPrintLnBold("You got the CM16");
                    player.TakeAllWeapons();
                    player.GiveWeapon("iw5_m16_mp");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("iw5_m16_mp");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 33;
                        *(int*)camoOffsets[ID] = 15;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_cm901_mp_camo15");
                            player.GiveMaxAmmo("iw5_cm901_mp_camo15");
                            player.SetWeaponAmmoClip("iw5_cm901_mp_camo15", 30);
                        });
                    });
                    break;
                case 36:
                    player.IPrintLnBold("You got the Dragunov-47 Target Finder");
                    player.TakeAllWeapons();
                    player.GiveWeapon("iw5_ak47_mp_eotech");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("iw5_ak47_mp_eotech");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 41;
                        *(int*)camoOffsets[ID] = 15;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_dragunov_mp_camo15");
                            player.GiveMaxAmmo("iw5_dragunov_mp_camo15");
                            player.SetWeaponAmmoClip("iw5_dragunov_mp_camo15", 20);
                        });
                    });
                    OnInterval(50, () =>
                        {
                            TargetFinder(player);
                            return true;
                        });
                    break;
                case 37:
                    player.IPrintLnBold("You got the MP12");
                    player.TakeAllWeapons();
                    player.GiveWeapon("iw5_aa12_mp_reflex");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("iw5_aa12_mp_reflex");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 18;
                        *(int*)camoOffsets[ID] = 47;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_mp5_mp_eotechsmg_camo15");
                            player.GiveMaxAmmo("iw5_mp5_mp_eotechsmg_camo15");
                            player.SetWeaponAmmoClip("iw5_mp5_mp_eotechsmg_camo15", 30);
                        });
                    });
                    break;
                case 38:
                    player.IPrintLnBold("You got the Skorpion5");
                    player.TakeAllWeapons();
                    player.GiveWeapon("iw5_mp5_mp");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("iw5_mp5_mp");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 15;
                        *(int*)camoOffsets[ID] = 47;
                        *(int*)attachOffsets[ID] = 4;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_skorpion_mp_eotechsmg_xmags_camo15");
                            player.GiveMaxAmmo("iw5_skorpion_mp_eotechsmg_xmags_camo15");
                            player.SetWeaponAmmoClip("iw5_skorpion_mp_eotechsmg_xmags_camo15", 30);
                        });
                    });
                    break;
                case 39:
                    player.IPrintLnBold("You got the FAR-S");
                    player.TakeAllWeapons();
                    player.GiveWeapon("iw5_fad_mp_reflex");
                    AfterDelay(250, () =>
                    {
                        player.SwitchToWeaponImmediate("iw5_fad_mp_reflex");
                    });
                    AfterDelay(400, () =>
                    {
                        player.TakeAllWeapons();
                        *(int*)gunOffsets[ID] = weaponOffset + 31;
                        *(int*)camoOffsets[ID] = 175;
                        *(int*)attachOffsets[ID] = 8;
                        AfterDelay(250, () =>
                        {
                            player.SwitchToWeaponImmediate("iw5_scar_mp_eotech_shotgun_xmags_camo15");
                            player.GiveMaxAmmo("iw5_scar_mp_eotech_shotgun_xmags_camo15");
                            player.SetWeaponAmmoClip("iw5_scar_mp_eotech_shotgun_xmags_camo15", 45);
                        });
                    });
                    break;
            }
        }
        public override void OnPlayerKilled(Entity player, Entity inflictor, Entity attacker, int damage, string mod, string weapon, Vector3 dir, string hitLoc)
        {
            if (player.CurrentWeapon == "iw5_dragunov_mp_camo15")
                player.ThermalVisionFOFOverlayOff();
            player.TakeAllWeapons();
        }
        public bool TargetFinder(Entity player)
        {
            if (player.CurrentWeapon == "iw5_dragunov_mp_camo15")
            {
                if (player.PlayerAds() > 0.9)
                    player.ThermalVisionFOFOverlayOn();
                else player.ThermalVisionFOFOverlayOff();
                return true;
            }
            else return false;
        }
    }
}
