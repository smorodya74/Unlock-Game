using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIFirstL : MonoBehaviour
{
    public TextMeshProUGUI output;
    public TMP_InputField login;
    public TMP_InputField password;
    public void Button()
    {
        if (login.text == "admin" && password.text == "admin") {
            output.text = "Мдаааа…у “более опытных специалистов” убираю слово “более” ... возможно и “опытные”..." +
        "\r\nТак делать нельзя. Логин и пароль должны иметь сложную структуру, чтобы хакерам было сложно подобрать. " +
        "Часто у каждой организации свои генераторы паролей и логинов, которые строятся по определенным правилам." +
        " Например первые буквы фио + дата рождения + год прихода на работу. \r\n"; ;
        }
        else if(login.text == "test" && password.text == "12345")
        {
            output.text = "Я так понимаю это тестовый пользователь… " +
                "но даже тестовых пользователей нужно удалять, либо ставить хорошую защиту, чтобы избежать лишней утечки информации.";
        }
        else
        {
            output.text = "Хмм... Что-то не то.\r\n" +
                "Попробуй воспользоваться вариантом из списка.";
        }
    }
}
