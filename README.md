# AWP

把 **AWP 狙击枪**加进 R.E.P.O.：单发、高伤害、慢射速，适合一枪一个的大怪。

交流：**#腾讯频道：pd77525911**

---

## 参数

| 项 | 值 |
|---|---|
| 伤害 | **400**（仅对敌人；不对玩家造成伤害，防误伤）|
| 射速 | **2.5 秒一发**（含换弹）|
| 备弹 | **3 发**（电池 3 格，打完换电池）|
| 价格 | 基础 12,500~17,500（商店按层数倍率 → 约 5 万~7 万）|
| 后坐力 | 6 |
| 体积 | large_high |
| 模型尺寸 | 1.15 米 |

---

## 功能

| 功能 | 说明 |
|---|---|
| **真单发** | 附带 `AWPGunFix.dll`，每次射击后复位扳机 → 一次按键 = 一发 |
| **固定音效** | 枪声为原速播放（Pitch 1.0），无随机音高 |
| **自定义枪身 Shader** | 打进包内的自写 shader，不依赖游戏内置 shader（避免材质变紫红）|

---

## 依赖

| 依赖 | 说明 |
|---|---|
| BepInEx 5.4.x | 必需 |
| [REPOLib](https://thunderstore.io/c/repo/p/Zehs/REPOLib/) **4.3.0** | 必需（加载 `.repobundle` 并注册物品）|

---

## 安装

用模组管理器安装即可。手动安装时把内容放进 `BepInEx/plugins/cn_xc-AWP/`：

```
AWP.repobundle
AWPGunFix.dll
```

---

## 已知限制

- 仅单人游戏测试，联机未验证

---

## 模型来源与许可证

| 项 | 内容 |
|---|---|
| 模型 | **AWP Counter-Strike 2** |
| 作者 | **blazitt**（Sketchfab）|
| 原页面 | https://sketchfab.com/3d-models/awp-counter-strike-2-5709ec5d66ed4061a9e1eb4d906c9729 |
| 许可证 | **Creative Commons Attribution (CC BY)** |

> 依据 CC BY，使用本模型需注明作者与原链接。
