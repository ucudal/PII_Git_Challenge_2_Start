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
[revert](https://git-scm.com/docs/git-revert), y
[checkout](https://git-scm.com/docs/git-checkout).

Asumimos que has completado el [desafío #1 de
Git](https://github.com/ucudal/PII_Git_Challenge_1_Start). Deberás continuar
trabajando en el repositorio creado en ese ejercicio.

## Pasos

## 1. Revertir un cambio incorrecto

En este paso veremos qué puedes hacer cuando sin darte cuenta haces un cambio
incorrecto y quieres volver atrás; con Git es posible usando [`git
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
  > - feature-addition
  > - feature-subtraction
  > - feature-multiplication
  > - feature-division

  En caso de que la rama no sea la tuya, cámbiate de rama con `git checkout`
  seguido del nombre de la rama.

- Introduce un cambio incorrecto en la clase que has implementado: retorna `0`
  como resultado de la operación.

  Por ejemplo, si la operación fuera la suma, el código debería quedar así:

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
  commit 64c8f1a9812d7ade807430e10dd36d933dd35b7f (HEAD -> feature-addition, origin/feature-addition)
  Author: Luis Suárez <lucho@nacional.com>
  Date:   Mon Jul 29 10:15:30 2024 +0200

      Cambio incorrecto
  ```

  Este texto no aparece directamente en la consola, sino en un editor de texto
  llamado [`vi`](https://en.wikipedia.org/wiki/Vi_(text_editor)). Git muestra la
  lista en el editor `vi` para que puedas recorrerla fácilmente presionando
  <kbd>↑</kbd> y <kbd>↓</kbd> para moverte hacia el inicio o el final
  respectivamente.

  Utiliza el mouse para seleccionar el `<commit-id>`, en el ejemplo
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

- Deshace los cambios usando [git revert](https://git-scm.com/docs/git-revert).
  Este comando revierte los cambios realizados en el *commit* indicado y
  registra un nuevo *commit*. Ejecuta el siguiene comando, reemplazando
  `<commit-id>` por el que copiaste anteriormente, y `<nombre-rama>` por la rama
  en la que vienes trabajando.

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

  ```
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
  > `Detached head` significa que `HEAD` apunta a un *commit*  específico y no a
  > una rama. Mira [este link](https://git-scm.com/docs/git-checkout#_detached_head)
  > para obtener más información.

  Examina el código para confirmar que estás viendo la versión inicial antes de
  que hicieras tus primeros cambios.

  Vuelve a la última versión ejecutando el siguiente comando, donde
  `<nombre-rama>` es el nombre de la rama en la que venías trabajando:

  ```bash
  git checkout <nombre-rama>
  ````

<!-- ## 3. Hacer *reset* a un estado anterior

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
  calculadora simple sino para una calculadora científica. Tenemos que eliminar
  los dos últimos cambios. Asumamos a efectos de este ejercicio que queremos
  volver a la situación anterior a agregar estos dos últimos cambios. Podemos
  hacerlo  con [git reset](https://git-scm.com/docs/git-reset).

  Este comando tiene tres modos de operación:

  - Reinicio mixto (predeterminado): el modo predeterminado de `git reset` es un reinicio mixto. Mueve el puntero de la rama y el HEAD a la confirmación de destino mientras limpia el área de preparación. Esto es útil cuando desea desconfirmar y deshacer la preparación de sus cambios, pero mantenerlos en su directorio de trabajo.

  Reinicio suave (--soft): un reinicio suave en Git es una forma de deshacer los cambios en su directorio de trabajo y volver a una confirmación específica mientras mantiene los cambios que ha preparado. Este modo mueve el puntero de la rama y el HEAD a la confirmación de destino, pero deja los cambios en el área de preparación. El área de preparación (también conocida como índice) en Git es un área de almacenamiento temporal para los cambios que aún no se han confirmado. Cuando realiza cambios en un archivo, los cambios se colocan primero en su directorio de trabajo. Luego, puede usar el comando git add para preparar los cambios para la próxima confirmación. Un reinicio suave se usa a menudo cuando desea "desconfirmar" sus cambios, pero mantenerlos en su área de preparación para otra confirmación.

Reinicio completo (--hard): este modo mueve el puntero de la rama y el HEAD a la confirmación de destino, limpia el área de preparación y descarta cualquier cambio en el directorio de trabajo. Tenga cuidado con este modo, ya que elimina permanentemente los cambios no confirmados.

  Ejecuta el siguiente comando:
  ```bash
  git reset HEAD~1
  ```


```bash
git reset --hard <id-del-commit-anterior>
```

## 4. Rebase para reorganizar *commits*

```bash
git checkout feature-addition
git rebase master
git push -f origin feature-addition
``` -->
