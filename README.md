UnityのEvent Triggerで動くボタン

* 必要なライブラリ
  * DOTween
  * OdinInspector

* C#の動作バージョン
  * C# 6.0以上

* 使い方 （ETButton）
  1. Canvasを作成してImageを作成
  2. 作成したImageのGameObjectにETButtonをアタッチ
  3. イベントを設定
  ```
  void Awake ()
  {
    // クリック、タップ（引数にActionを渡す）
    GetComponent<ETButton> ().RegistClickEvent (Click);
    GetComponent<ETButton> ().RegistTouchEvent (Touch);
  }

  void Click () =>
    Debug.Log ("Click");

  void Touch () =>
    Debug.Log ("Touch");
  ```

* 使い方  (ETButtonDOTween)
  1. Canvasを作成してImageを作成
  2. 作成したImageのGameObjectにETButtonDOTweenをアタッチ
  3. インスペクタで動きを設定
      - Common ... ボタンの共通の動き（チェックを外すと個別に設定可能）
        - Target ... 動かす対象オブジェクト
        - Push / Duration ... 動かす時間（押したとき）
        - Push / Easing ... 動きのカーブ（押したとき）
        - Release / Duration ... 動かす時間（押したとき）
        - Release / Duration ... 動きのカーブ（押したとき）
      - Fade ... Color, Spriteを設定した透明度でフェードイン
        - Fade Front ... オンにするとフェード画像を最前面に表示
      - Move ... localPositionを設定した数値に移動
      - Rotate ... rotationを設定した数値に変形
      - Scale ... localScaleを設定した数値に変形


