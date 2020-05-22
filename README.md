UnityのEvent Triggerで動くボタン

* 必要なライブラリ
  * DOTween
  * OdinInspector

* C#の動作バージョン
  * C# 6.0以上

* 使い方 （ETButton）
  1. Canvasを作成してGameObjectを作成
  2. 作成したGameObjectにETButtonをアタッチ
  3. イベントを設定
  ```
  void Awake ()
  {
    // クリック
    GetComponent<ETButton> ().RegistClickEvent (Click);

    // タップ
    GetComponent<ETButton> ().RegistTouchEvent (Click);
  }

  void Click () =>
    Debug.Log ("Click");

  void Touch () =>
    Debug.Log ("Touch");
  ```

