[![Codacy Badge](https://api.codacy.com/project/badge/Grade/5330da13535947d08c117112066f3407)](https://app.codacy.com/manual/tryallthethings/DNS-Swapper?utm_source=github.com&utm_medium=referral&utm_content=tryallthethings/DNS-Swapper&utm_campaign=Badge_Grade_Dashboard)
# DNS-Swapper [![Build Status](https://travis-ci.org/tryallthethings/DNS-Swapper.svg?branch=master)](https://travis-ci.org/tryallthethings/DNS-Swapper) ![Downloads](https://img.shields.io/github/downloads/tryallthethings/DNS-Swapper/total.svg?style=flat) [![Latest Release](https://img.shields.io/github/v/release/tryallthethings/DNS-Swapper.svg?logo=github)](https://github.com/tryallthethings/DNS-Swapper/releases)
## Download
Latest version can be downloaded from here: [https://github.com/tryallthethings/DNS-Swapper/releases](https://github.com/tryallthethings/DNS-Swapper/releases)
## Purpose
This little tool was written out of my need to quickly switch my network configuration between two different DNS servers.
Its main purpose is to be used together with [Pi-Hole](https://pi-hole.net). If you have set your DNS to your Pi-Hole IP you would either need to change it manually in your windows configuration or disable Pi-Hole temporarly through the Web-GUI (which would disable it for other users as well).

## Why
Why would you need to do this in the first place? Well, Pi-Hole is blocking most of the Ads. So in case you want to see them temporarly or use Google Ad-Links once in a while you will need to unblock ads temporarly. This is where DNS-Swapper shines.

## Usage
DNS-Swapper will start automatically with Windows after installation and reside in your taskbar as a blue icon initially. Right Click on it and select open. In the opened window you can select the network interface you want to use DNS-Swapper with. Then you add in your non ad-blocking DNS (e.g. your home network routers gateway IP address) and your Pi-Holes IP address. Settings are saved automatically when the tool is closed or can be triggered manually via File -> Save.
That's all the configuration required. Minimize it back to the taskbar. Left clicking the icon will switch between the two DNS-Servers. A blue icon is the primary (ad-blocking) DNS-Server - a red icon the non ad-blocking DNS. If it shows a yellow exclamation mark something went wrong while switching the DNS-Servers.
On Windows machines with UAC enabled a UAC warning will open every time the tool is trying to change the DNS servers (swap.exe). 

**Please note that this tool will currently remove all additional DNS-servers you might have configured**

## Future features
-   Swap DNS-Server with Keyboard-Shortcut
-   Don't mess with additional DNS-Servers
-   IPv6 support?
