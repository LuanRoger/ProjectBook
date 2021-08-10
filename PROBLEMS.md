## Problemas frequentes
### Iniciar a instância
Às vezes o programa não vai conseguir iniciar a instância do banco de dados, então isso deve ser feito manualmente no CMD/PowerShell:
~~~powershell
sqllocaldb i
~~~
Para ver as intâncias.

Copie o nome da intâncias e:
~~~powershell
 sqllocaldb s "nome da instancia"
~~~
Para iniciar a instância.

### Untrusted App
Este problema é causado na primeira vez que o programa é instalado.
Para resolver-lo você deve especificar de que aquele certificado/assinatura digital é confiavel para este computador:

1. Abra as propriedades do instalador > Assinaturas Digitais > Selecione a assinatura > Detalhes.
2. Vá em Exibir Certificado > Instalar Certificado…
3. Marque "Máquina Local” e Avançar > Marque “Colocar todos os certificados no repositório a seguir” > Selecione “Autoridades de Certificação Raiz Confiável" clique em OK e depois Avançar.
4. Conclua o procedimento.