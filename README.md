# 大兔兔营救 Tuutua 🐰

一个用 C# 写的控制台（命令行）RPG 小游戏：控制「大兔兔」移动、和 Boss 战斗、救出公主 Tuutua。

> C# 课程入门实践项目，用控制台实现了游戏场景、战斗循环与多结局。

## ✨ 玩法

- `W A S D` 移动，`J` 确认 / 攻击
- 流程：开始界面 → 游戏场景 → 胜利 / 失败结局
- 和 Boss 回合制战斗，打败 Boss 后救出公主

## 🛠️ 技术点

- C# 控制台编程：光标定位、前景色、按键监听
- 场景状态机（开始 / 游戏 / 结束）
- 回合制战斗的数值计算与边界碰撞

## 🚀 如何运行

```bash
dotnet run
```

或在 Visual Studio 中打开 `tuutua-rescue.csproj` 直接运行。

> 提示：本游戏使用了 Windows 控制台窗口 API，建议在 Windows 上运行。

## 📂 文件

- `Program.cs` —— 游戏全部逻辑
- `tuutua-rescue.csproj` —— 项目文件
