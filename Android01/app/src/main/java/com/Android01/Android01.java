
package com.Android01;

import android.app.Activity;
import android.widget.TextView;
import android.os.Bundle;

public class Android01 extends Activity
{
    /** Chamado quando a atividade é criada pela primeira vez. */
    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);

        /* Crie um TextView e defina o texto como "Hello World" */
        TextView  tv = new TextView(this);
        tv.setText("Hello World!");
        setContentView(tv);
    }
}
