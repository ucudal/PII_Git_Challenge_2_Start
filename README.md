<img alt="UCU" src="https://www.ucu.edu.uy/plantillas/images/logo_ucu.svg"
width="150"/>

# Universidad Católica del Uruguay

## Facultad de Ingeniería y Tecnologías

### Programación II

# Desafío Git #2: Calculadora Colaborativa

## Objetivo

Continuar trabajando con la aplicación de calculadora simple en C# donde cada
estudiante del equipo contribuyó con una operación diferente (suma, resta,
multiplicación, división). Practicarás los siguientes comandos de Git:
[log](https://git-scm.com/docs/git-log),
[revert](https://git-scm.com/docs/git-revert),
[checkout](https://git-scm.com/docs/git-checkout) y
[reset](https://git-scm.com/docs/git-reset).

Asumimos que has completado el [desafío #1 de
Git](https://github.com/ucudal/PII_Git_Challenge_1_Start). Deberás continuar
trabajando en el repositorio creado en ese ejercicio.

## Pasos

## 1. Revertir un cambio incorrecto

En este paso veremos qué puedes hacer cuando, sin darte cuenta, haces *commit*
de un cambio incorrecto y quieres volver atrás; con Git es posible usando [`git
revert`](https://git-scm.com/docs/git-revert).

- Primero confirma que estás en tu rama de trabajo y que no hay modificaciones
  pendientes. Ejecuta el siguiente comando:

  ```bash
  git status
  ```

  Deberías ver un mensaje similar al siguiente:

  ```bash
  On branch <nombre-rama>
  nothing to commit, working tree clean
  ```

  > Recuerda que `<nombre-rama>` es uno de los siguientes:
  > - suma
  > - resta
  > - multiplica
  > - divide

  En caso de que la rama no sea la tuya, cámbiate de rama con `git checkout`
  seguido del nombre de la rama.

- Introduce un cambio incorrecto en la clase que has implementado: por ejemplo,
  retorna `0` como resultado de la operación; si la operación fuera la suma, el
  código debería quedar así:

  ```csharp
  public class Addition
  {
      public static int Add(int a, int b)
      {
          return 0; // Cambio incorrecto
      }
  }
  ```

- Haz *commit* de esos cambios, ejecutando los siguientes comandos:

  ```bash
  git add .
  git commit -m "Cambio incorrecto"
  git push origin <nombre-rama>
  ```

  Ejecuta el programa haciendo clic en el botón
  ![](https://intellij-icons.jetbrains.design/icons/AllIcons/expui/gutter/run_dark.svg)
  `Run 'Program'` que aparece en la esquina superior derecha de Rider; o en la
  terminal mediante el siguiente comando:

  ```bash
  dotnet run --project ./src/Program/Program.csproj
  ```

  Verás un resultado como el siguiente; el resultado incorrecto dependerá de la
  operación que hayas implementado:

  ```bash
  0
  9
  9
  9
  ```

  Claramente hay un error —lo hicimos a propósito—; en un escenario real, recién
  te darías cuenta de que hay algo incorrecto cuando pruebes tu programa.
  Dependiendo del caso tienes dos opciones: arreglarlo, o ir hacia atrás; en
  este ejercicio iremos por la segunda opción.

- Ejecuta [`git log`](https://git-scm.com/docs/git-log) para ver la historia de
  los cambios, mediante el siguiente comando:

  ```bash
  git log
  ```

  La salida luce similar a la siguiente, tú vas a ver más texto:

  ```bash
  commit 64c8f1a9812d7ade807430e10dd36d933dd35b7f (HEAD -> suma, origin/suma)
  Author: Luis Suárez <lucho@nacional.com>
  Date:   Mon Jul 29 10:15:30 2024 +0200

      Cambio incorrecto
  ```

  Este texto no aparece directamente en la consola, sino en un editor de texto
  llamado [`vi`](https://en.wikipedia.org/wiki/Vi_(text_editor)). Git muestra la
  lista en el editor `vi`, para que puedas recorrerla fácilmente presionando
  <kbd>↑</kbd> y <kbd>↓</kbd> para moverte hacia el inicio o el final,
  respectivamente.

  Utiliza el *mouse* para seleccionar el `<commit-id>`, en el ejemplo
  `64c8f1a9812d7ade807430e10dd36d933dd35b7f`; luego copia el texto al
  portapapeles.

  > [!NOTE]
  > Es suficiente con usar los primeros 8 caracteres del `<commit-id>`, pero si
  > te da lo mismo, cópialo entero.

  Una vez que haz copiado el `<commit-id>`, debes abandonar `vi` presionando
  <kbd>Esc</kbd>, luego <kbd>:</kbd> y luego <kbd>Q</kbd>, también conocido como
  *command quit*.

  > [!TIP]
  > ¿No quieres usar `vi`? Puedes configurar Git para que use otro editor de
  > texto, ¡incluso Rider!.
  > Ejecuta el siguiente comando en la terminar para cambiar el editor de texto
  > de `vi` a Rider:
  > ```bash
  > git config core.editor rider
  >```

- Deshace los cambios usando [git revert](https://git-scm.com/docs/git-revert),
  seguido del `<commit-id>`. Este comando deshace los cambios realizados en el
  *commit* indicado y registra un nuevo *commit*. Ejecuta el siguiene comando,
  reemplazando `<commit-id>` por el que copiaste anteriormente, y
  `<nombre-rama>` por la rama en la que vienes trabajando.

  ```bash
  git revert <commit-id>
  git push origin <nombre-rama>
  ```

  Nuevamente Git abre `vi` —o Rider si lo configuraste anteriormente— para que
  puedas editar tu mensaje para el *commit* que se registra al final del `git
  revert`. Puedes editar el mensaje o dejar el mensaje propuesto. En caso de que
  uses `vi`, para salir presiona <kbd>Esc</kbd>, luego <kbd>:</kbd> y luego
  <kbd>W</kbd>, también conocido como *command write*; a continuación abadona
  `vi` presionando <kbd>:</kbd> y luego <kbd>Q</kbd>, o *command quit*. En caso
  de que uses Rider, simplemente guarda y cierra el archivo temporal en el que
  editaste el mensaje.

  Puedes examinar el código para ver que luce como antes de introducir el cambio
  erróneo. Ejecuta el programa nuevamente haciendo clic en el botón
  ![](https://intellij-icons.jetbrains.design/icons/AllIcons/expui/gutter/run_dark.svg)
  `Run 'Program'` que aparece en la esquina superior derecha de Rider; o en la
  terminal mediante el siguiente comando:

  ```bash
  dotnet run --project ./src/Program/Program.csproj
  ```

  Verás el resultado correcto nuevamente:

  ```bash
  9
  9
  9
  9
  ```

## 2. Hacer *checkout* de un *commit* anterior cualquiera

Puedes ver cómo lucía el código en cualquier momento de la historia del
repositorio utilizando el comando [git
checkout](https://git-scm.com/docs/git-checkout). Ya has usado este comando,
pero ahora tendrá otros parámetros.

- Utiliza [`git log`](https://git-scm.com/docs/git-log) como antes para ver la historia de
  los cambios, mediante el siguiente comando:

  ```bash
  git log
  ```

- Copia el `<commit-id>` de uno de los primeros commits, el que dice `Initial
  commit`. Luego ejecuta el siguiente comando:

  ```bash
  git checkout <commit-id>
  ```

  Git muestra un mensaje similar al siguiente:

  ```text
  Note: switching to <commit-id>.

  You are in 'detached HEAD' state. You can look around, make experimental
  changes and commit them, and you can discard any commits you make in this
  state without impacting any branches by switching back to a branch.

  If you want to create a new branch to retain commits you create, you may
  do so (now or later) by using -c with the switch command. Example:

    git switch -c <new-branch-name>

  Or undo this operation with:

    git switch -

  Turn off this advice by setting config variable advice.detachedHead to false

  HEAD is now at bdd7c4d Initial commit
  ```

  > [!TIP]
  > `HEAD` es lo que usa Git para identificar "el *commit*  donde estás
  > trabajando ahora mismo". Habitualmente `HEAD` apunta a un *commit* en la
  > rama actual. `Detached head` significa que `HEAD` apunta a un *commit*
  > específico en ninguna rama. Mira [este
  > link](https://git-scm.com/docs/git-checkout#_detached_head) para obtener más
  > información.

  Examina el código para confirmar que estás viendo la versión inicial antes de
  que hicieras tus primeros cambios.

  > [!NOTE]
  > A menos que en este estado crees una rama y hagas algún *commit* en ella, lo
  > que estás viendo es temporal, es decir, cuando te cambias a otra rama
  > volverá a lo que había en esa rama.

  Vuelve a la última versión ejecutando el siguiente comando, donde
  `<nombre-rama>` es el nombre de la rama en la que venías trabajando:

  ```bash
  git checkout <nombre-rama>
  ````

## 3. Hacer *reset* a un estado anterior

Hay otra forma de deshacer los cambios que histe en el paso [1. Revertir un
cambio incorrecto](#1-revertir-un-cambio-incorrecto). Para mostrarlo vamos a
hacer más cambios en nuestro programa.

- Agrega la siguiente clase al final del archivo
  [Program.cs](./src/Program/Program.cs):

  ```csharp
  public class Power
  {
      public static int Squared(int a)
      {
          return a * a;
      }
  }
  ```

  Agrega este cambio en un nuevo *commit*. Ya deberías saber como hacerlo, pero
  si no lo recuerdas, estos serían los comandos:

  ```bash
  git add .
  git commit -m "Nueva operación"
  ```

- Agrega un comentario a esa clase, para que el código luzca así:

  ```csharp
  // Devuelve a al cuadrado
  public class Power
  {
      public static int Squared(int a)
      {
          return a * a;
      }
  }
  ```

  Nuevamente agrega este cambio en otro *commit*; aquí van los comandos:

  ```bash
  git add .
  git commit -m "Agrego comentario"
  ```

- Supongamos que elevar un número al cuadradado no es una operación para nuestra
  calculadora simple, sino para una calculadora científica. Tenemos que eliminar
  los dos últimos cambios. Asumamos a efectos de este ejercicio que queremos
  volver a la situación anterior a agregar estos dos últimos cambios. Podemos
  hacerlo  con [git reset](https://git-scm.com/docs/git-reset), seguido de una
  referencia a un *commit*.

  > [!NOTE]
  > Para este comando, aunque también para otros, el parámetro que indica el
  > *commit* al que quieres volver, puede ser uno de los siguientes: `HEAD~1`
  > referencia un *commit* antes del actual, digamos, el padre; `HEAD~2`
  > referencia dos *commit* antes del actual, digamos, el abuelo; y así
  > sucesivamente. Existen otras referencias, pero con que conozcas estas
  > alcanza por ahora.

  > [!TIP]
  > Recuerda que `HEAD` es lo que usa Git para identificar "el *commit*  donde
  > estás trabajando ahora mismo".

  Este comando tiene tres modos de operación:

  - Reinicio mixto, que es el predeterminado, o sea, cuando no indica un
    parámetro adicional: el modo predeterminado de `git reset` es un reinicio
    mixto. Mueve el puntero de la rama y el `HEAD` al *commit* que indiques,
    mientras limpia la *staging area* y deja tus cambios en el *working folder*.
    Esto es útil cuando deseas eliminar un *commit* y dejar vacía la *staging
    area*, pero mantener los cambios en el *working folder*.

  - Reinicio suave, con el parámetro `--soft`: un reinicio suave en Git es una
    forma de deshacer los cambios en tu *working folder* y volver a un *commit*
    específico, mientras mantienes los cambios que la *staging area*. Este modo
    mueve el puntero de la rama y el `HEAD` al *commit* que indiques, pero deja
    los cambios en la *staging area*. Un reinicio suave se usa a menudo cuando
    deseas deshacer un *commit*, pero mantener los cambios en la *staging area*
    para otro *commit*.

  - Reinicio completo, con el parámetro `--hard`: este modo mueve el puntero de
    la rama y el `HEAD` al *commit* indicado, limpia la *staging area* y
    descarta cualquier cambio en el *working folder*. Ten cuidado con
    este modo, ya que elimina permanentemente los cambios de los que no hayas
    hecho *commit*.

  La tabla a continuación, resume las diferencias:

  | Modo  | *Staging area*       | *Working folder*            | Uso típico |
  |-------|----------------------|-----------------------------|------------|
  | Mixed | Queda vacía          | Mantiene los cambios        | Deshacer *commits* recientes, pero conservar cambios para re‑seleccionar qué va al próximo *commit* |
  | Soft  | Mantiene los cambios | Mantiene los cambios        | Rehacer *commits* recientes, manteniendo todo listo para volver a hacer *commit* |
  | Hard  | Queda vacía          | Vuelve al *commit* indicado | Volver a un estado limpio, descartando cambios no deseados |

  En todos los casos, el *commit* actual pasa a ser el que indiques al ejecutar
  el comando.

- Ejecuta los siguientes comandos:

  ```bash
  git reset HEAD~1
  git status
  ```

  Verás una salida similar a esta:

  ```text
  On branch ...
  Changes not staged for commit:
    (use "git add <file>..." to update what will be committed)
    (use "git restore <file>..." to discard changes in working directory)
          modified:   src/Program/Program.cs

  no changes added to commit (use "git add" and/or "git commit -a")
  ```

  Esto confirma que la *staging area* está vacía, y que el archivo `Program.cs`
  está modificado.

  Examina el archivo `Program.cs`, verás que tiene el comentario que hiciste en
  el último *commit*.

  Si ejecutas `git log`, verás que el último *commit* es el de la nueva
  operación, y no el del comentario.

- Ejecuta ahora los siguientes comandos, pero `git reset` con la opción
  `--hard`:

  ```bash
  git reset HEAD~1 --hard
  git status
  ```

  Verás una salida similar a esta:

  ```bash
  On branch ...
  nothing to commit, working tree clean
  ````

  Esto confirma que la *staging area* está vacía y que el *working folder* no
  tiene modificaciones. Si examinas el archivo `Program.cs`, verás que no tiene
  la operación agregada en este paso. Si ejecutas `git log`, verás que el último
  *commit* es que hiciste en el paso [1. Revertir un cambio
  incorrecto](#1-revertir-un-cambio-incorrecto) de este desafío.

## 4. Usar *commit --amend* para modificar el último *commit*

En este paso vamos a ver qué cómo puedes modificar el último *commit*.

> [!WARNING]
> Idealmente debes modificar el último *commit* con el comando `commit --amend`
> antes de enviar tus cambios al repositorio remoto con `git push`. Si el
> *commit* ya está en el repositorio remoto, no te recomandamos usar `commit
> --amend`.

- Agrega al comienzo del método `void Main()` de la clase `Program` la impresión
  de un mensaje en la consola con `Console.WriteLine("Demo calculadora");`. El
  código de esa clase debería quedar así:

  ```csharp
  public static class Program
  {
      public static void Main()
      {
          Console.WriteLine("Demo calculadora");
          Console.WriteLine(Suma.Sumar(1, 2));
          Console.WriteLine(Resta.Restar(3, 4));
          Console.WriteLine(Multiplicacion.Multiplicar(5, 6));
          Console.WriteLine(Division.Dividir(7, 8));
      }
  }
  ```

- Agrega un nuevo archivo en la raíz de tu repositorio, con el siguiente
  comando:

  ```bash
  echo Demo >> file.txt
  ````

  Esto crea un archivo llamado `file.txt`.

- De forma intencional, a efectos de este ejercicio, haremos *commit* sólo del
  archivo `file.txt`, pero no de los cambios en `Program.cs`. Ejecuta los
  siguientes comandos:

  ```bash
  git add file.txt
  git commit -m "Probando amend"
  git status
  ```

  Verás una salida como la siguiente:

  ```text
  On branch ...
  Changes not staged for commit:
    (use "git add <file>..." to update what will be committed)
    (use "git restore <file>..." to discard changes in working directory)
          modified:   src/Program/Program.cs

  no changes added to commit (use "git add" and/or "git commit -a")
  ```

  Ahora podemos querer cambiar dos cosas en el último *commit*; primero, agregar
  el archivo que faltó; y luego, cambiar el mensaje.

- Ejecuta el siguiente comando, para cambiar solamente el mensaje del último
  *commit*:

  ```bash
  git commit --amend -m "Mensaje en la calculadora"
  ```

  Esto cambiará solamente el mensaje en el último *commit*. Puedes confirmarlo
  haciendo `git status` para ver que `Program` sigue en el working folder y `git
  log` para ver los mensajes de los últimos *commit*. Si estás usando `vi` como
  editor para Git -verás `:` al final de la lista de *commits*-, recuerda usar
  <kbd>Q</kbd> para salir.

- Ejecuta ahora los siguientes comandos, para agregar el archivo `Program.cs` al
  último *commit*, y quitar el archivo `file.txt`:

  ```bash
  git rm --cached file.txt
  git add src/Program/Program.cs
  git commit --amend
  ````

  Git puede mostrar un editor de texto; si estás usando `vi` recuerda que debes
  usar <kbd>:</kbd>, seguido de <kbd>Q</kbd>, para salir de `vi`. Podrás ver que
  el mensaje del último *commit* no ha cambiado -aunque podrías cambiar el
  mensaje en el editor de texto-,  así como el resultado del *commit*
  modificado.

  El comando `git commit --amend` agregará el archivo `Program.cs` al *commit* y
  quitará el archivo `file.txt`. Puedes confirmarlo haciendo `git status` para
  ver que `file.txt` sigue en el working folder y `git log` para ver los
  mensajes de los últimos *commit*. Si estás usando `vi` como editor para Git
  -verás `:` al final de la lista de *commits*-, recuerda usar <kbd>Q</kbd> para
  salir.

- Borra el archivo `file.txt`. El *working folder* no debería tener ninguna
  modificación. Puedes confirmarlo con `git status`.
