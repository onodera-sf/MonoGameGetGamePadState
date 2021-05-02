using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GetGamePadState
{
	/// <summary>
	/// ゲームメインクラス
	/// </summary>
	public class Game1 : Game
	{
    /// <summary>
    /// グラフィックデバイス管理クラス
    /// </summary>
    private readonly GraphicsDeviceManager _graphics = null;

    /// <summary>
    /// スプライトのバッチ化クラス
    /// </summary>
    private SpriteBatch _spriteBatch = null;

    /// <summary>
    /// スプライトでテキストを描画するためのフォント
    /// </summary>
    private SpriteFont _font = null;

    /// <summary>
    /// ゲームパッドの状態
    /// </summary>
    private GamePadState _gamePadState = GamePad.GetState(PlayerIndex.One);


    /// <summary>
    /// GameMain コンストラクタ
    /// </summary>
    public Game1()
    {
      // グラフィックデバイス管理クラスの作成
      _graphics = new GraphicsDeviceManager(this);

      // ゲームコンテンツのルートディレクトリを設定
      Content.RootDirectory = "Content";

      // マウスカーソルを表示
      IsMouseVisible = true;
    }

    /// <summary>
    /// ゲームが始まる前の初期化処理を行うメソッド
    /// グラフィック以外のデータの読み込み、コンポーネントの初期化を行う
    /// </summary>
    protected override void Initialize()
    {
      // TODO: ここに初期化ロジックを書いてください

      // コンポーネントの初期化などを行います
      base.Initialize();
    }

    /// <summary>
    /// ゲームが始まるときに一回だけ呼ばれ
    /// すべてのゲームコンテンツを読み込みます
    /// </summary>
    protected override void LoadContent()
    {
      // テクスチャーを描画するためのスプライトバッチクラスを作成します
      _spriteBatch = new SpriteBatch(GraphicsDevice);

      // フォントをコンテンツパイプラインから読み込む
      _font = Content.Load<SpriteFont>("Font");
    }

    /// <summary>
    /// ゲームが終了するときに一回だけ呼ばれ
    /// すべてのゲームコンテンツをアンロードします
    /// </summary>
    protected override void UnloadContent()
    {
      // TODO: ContentManager で管理されていないコンテンツを
      //       ここでアンロードしてください
    }

    /// <summary>
    /// 描画以外のデータ更新等の処理を行うメソッド
    /// 主に入力処理、衝突判定などの物理計算、オーディオの再生など
    /// </summary>
    /// <param name="gameTime">このメソッドが呼ばれたときのゲーム時間</param>
    protected override void Update(GameTime gameTime)
    {
      // ゲームパッドの状態を取得する
      _gamePadState = GamePad.GetState(PlayerIndex.One);

      // ゲームパッドの Back ボタン、またはキーボードの Esc キーを押したときにゲームを終了させます
      if (Keyboard.GetState().IsKeyDown(Keys.Escape))
      {
        Exit();
      }

      // 登録された GameComponent を更新する
      base.Update(gameTime);
    }

    /// <summary>
    /// 描画処理を行うメソッド
    /// </summary>
    /// <param name="gameTime">このメソッドが呼ばれたときのゲーム時間</param>
    protected override void Draw(GameTime gameTime)
    {
      // 画面を指定した色でクリアします
      GraphicsDevice.Clear(Color.CornflowerBlue);

      // スプライトの描画準備
      _spriteBatch.Begin();

      string stateMessage;

      // 左スティック
      _spriteBatch.DrawString(_font,
          "LeftStick : " +
              _gamePadState.ThumbSticks.Left.X.ToString("f8") + ", " +
              _gamePadState.ThumbSticks.Left.Y.ToString("f8"),
          new Vector2(20.0f, 25.0f), Color.White);

      // 右スティック
      _spriteBatch.DrawString(_font,
          "RightStick : " +
              _gamePadState.ThumbSticks.Right.X.ToString("f8") + ", " +
              _gamePadState.ThumbSticks.Right.Y.ToString("f8"),
          new Vector2(20.0f, 50.0f), Color.White);

      // 方向パッド
      stateMessage = "";
      if (_gamePadState.DPad.Up == ButtonState.Pressed)
      {
        stateMessage += "Up    ";
      }
      if (_gamePadState.DPad.Left == ButtonState.Pressed)
      {
        stateMessage += "Left  ";
      }
      if (_gamePadState.DPad.Down == ButtonState.Pressed)
      {
        stateMessage += "Down  ";
      }
      if (_gamePadState.DPad.Right == ButtonState.Pressed)
      {
        stateMessage += "Right ";
      }
      _spriteBatch.DrawString(_font, "DirectionalPad : " + stateMessage,
          new Vector2(20.0f, 75.0f), Color.White);


      stateMessage = "";
      // Aボタン
      if (_gamePadState.Buttons.A == ButtonState.Pressed)
      {
        stateMessage += "A ";
      }
      // Bボタン
      if (_gamePadState.Buttons.B == ButtonState.Pressed)
      {
        stateMessage += "B ";
      }
      // Xボタン
      if (_gamePadState.Buttons.X == ButtonState.Pressed)
      {
        stateMessage += "X ";
      }
      // Yボタン
      if (_gamePadState.Buttons.Y == ButtonState.Pressed)
      {
        stateMessage += "Y ";
      }
      // STARTボタン
      if (_gamePadState.Buttons.Start == ButtonState.Pressed)
      {
        stateMessage += "START ";
      }
      // BACKボタン
      if (_gamePadState.Buttons.Back == ButtonState.Pressed)
      {
        stateMessage += "BACK ";
      }
      // LBボタン
      if (_gamePadState.Buttons.LeftShoulder == ButtonState.Pressed)
      {
        stateMessage += "LB ";
      }
      // RBボタン
      if (_gamePadState.Buttons.RightShoulder == ButtonState.Pressed)
      {
        stateMessage += "RB ";
      }
      // 左スティックボタン
      if (_gamePadState.Buttons.LeftStick == ButtonState.Pressed)
      {
        stateMessage += "LeftStick ";
      }
      // 右スティックボタン
      if (_gamePadState.Buttons.RightStick == ButtonState.Pressed)
      {
        stateMessage += "RightStick ";
      }
      _spriteBatch.DrawString(_font, "Buttons : " + stateMessage,
          new Vector2(20.0f, 100.0f), Color.White);

      // トリガー
      _spriteBatch.DrawString(_font,
          "Trigger : " +
              _gamePadState.Triggers.Left.ToString("f8") + ", " +
              _gamePadState.Triggers.Right.ToString("f8"),
          new Vector2(20.0f, 125.0f), Color.White);

      // スプライトの一括描画
      _spriteBatch.End();

      // 登録された DrawableGameComponent を描画する
      base.Draw(gameTime);
    }
  }
}
