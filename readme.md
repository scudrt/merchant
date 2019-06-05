# **Merchants**
只是个作业


* ## **Requirement:**
    + Visual Studio 2015+
    + Unity3D 2019.1

* 统计行数 find assets/scripts -name "*.cs" |xargs wc -l

* ## **Version log**
    - TODO：
        + @scudrt:
            - 和同步功能对接
            - 继续完善合同类
            - 还剩3个prefab模型：影院、景区、学校
            - 增加一个金钱变化的数字效果(可选)
        + @Vivid233:
            - 解决timer的text遮挡问题
            - 适配UI的位置+大小与窗口的关系
            - 建造界面使用竖向排布
            - 建造界面增加一个建造费用的显示
            - destroy的消息接收在列表为空的时候处理一下
            - 各个按钮选择时颜色加深
            - 资金分配功能
            - 人才分配功能
            - 准备搞合同功能了（这是真的麻烦）
    + ### **version 0.2.5** :
        - 增加了人才的公司从属属性，Company增加雇佣、解雇人才的接口
        - 完成了Contract的部分设计
        - 导入并调整了多个建筑模型prefab
        - 为每个公司随机分配颜色
        - 建筑能够带来收入了
        - 人口能够随机自然增长了
    + ### **version 0.2.4** :
        - 增加了block的选中效果
        - 增加了人才的id识别
        - 支持了建筑信息的读取，包括建筑种类、预算、客流量、利润
        - 修正了景区传参的错误+美术馆文字显示的错误
        - 每种建筑都有自己的建造价格了
        - 去除了两个空指针和一个栈溢出的bug
    + ### **version 0.2.3** :
        - 资金分配界面写好了（数据显示要等建筑类写完。。。）
        - 完成了列表项脚本类
    + ### **version 0.2.2** ：
        - 完成了人才市场
        - 完成了雇佣和解雇功能
        - 添加了选择建筑类型按钮（然而还没添加事件）
        - City可以生成人才列表了
    + ### **version 0.2.1** :
        - 建造也要花钱了
        - 优化了building类的结构
        - 丰富了building的接口定义
        - 添加了医院的prefab
        - 将建筑的默认prefab改为了剑
        - 将building类改为了抽象类
        - 修改了一点点bug
        - 改了下命名中的错别字
        - 增加了公司信息的即时更新
        - 在Talent中写了一个随机生成talent的静态函数
    + ### **version 0.2.0** :
        - 给场景更换了名字，不叫samplescene了，叫gamescene
        - 改了设置，现在mainmenu是最开始运行的场景，gamescene在点击开始游戏后才会被加载
        - 去掉了blockUI退出的debug提示
        - 添加了医院、超市、银行、学校、餐厅、美术馆、电影院、体育馆、景区，但是没有内容，暂时不可用
        - 以后使用工厂模式生成建筑
    + ### **version 0.1.10** ：
        - 人才滚动列表已经可以完美运行
        - 创建了主菜单场景
        - 人才详细信息界面完成
	+ ### **version 0.1.9** :
		- 添加了人才滚动列表在TalentManageUI中，可以显示（测试时间比写代码时间要长。。。）
	+ ### **version 0.1.8** :
        - UI的awake使用setactive，并且由按钮唤醒它们
        - 每个物体自己禁用自己，直到游戏开始才enable
		- 人才列表显示代码
		- 解决了blockUI Panel可能同时显示的问题
    + ### **version 0.1.7** :
        - 找到了prefab的正确用法
        - 可以指定生成建筑的类型
        - 建筑、block大小随地图大小调整了
        - panel物体改为了更易理解的名字
        - 游戏开始前实现禁止与游戏物体互动
        - 加快了UI弹出速度
        - 增加了购买后的Block着色效果
    + ### **version 0.1.6** :
        - 去除了多余的onMouseEnter
        - 增加了卖出建筑功能（待测试）
        - 解决了Block变色效果有时不消失的问题
        - 实现了代码生成Block
        - 实现了代码生成指定building
        - 增加了block管理器
        - 增加了company管理器
        - 类内容丰富
        - UI部分的完善
        - 修改了时间的显示
    + ### **version 0.1.5** :
        - 添加了Company和Talent类
        - 增加了UI组件
        - 解决了UI不随游戏界面大小改变的问题
        - 时间允许暂停并且进入游戏后才开始时间流逝
        - 增加了population类
        - 缩小了UI尺寸
        - 换了背景音乐-一步之遥
	+ ### **version 0.1.4** :
		- 完善了UI的层次结构
		- 创建了滑动UI的模板
		- 对Building的状态进行了基本分类
    + ### **version 0.1.3** :
		- 创建文件夹对游戏资源分类
		- 创建Building模板，实现鼠标选择高亮
		- 实现了物体UI的滑动
		- 实现了Building与物体UI间的传递信息
    + ### **version 0.1.2** :
        - 支持昼夜时长不同
        - 美化日光、增加月光效果
        - Timer与阳光效果同步
        - 允许一定程度的上下旋转
        - 修复边界判定逻辑
        - 添加背景音乐-hop
        - 重新排布了各部件的逻辑结构   
    + ### **version 0.1.1** :
        - 修改了主菜单UI，添加了标题
        - 标题字体模糊问题解决
        - 镜头左右旋转
        - 绑定了退出按钮事件
        - 昼夜更替   
    + ### **Version 0.1.0** :
        - 镜头移动、拉伸以及其活动区域限制
        - 基本UI界面
        - 阴影效果
