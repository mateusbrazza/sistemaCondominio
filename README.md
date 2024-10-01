# SistemaCondominio
import static org.mockito.Mockito.*;
import static org.junit.Assert.*;
import org.junit.Before;
import org.junit.Test;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.MockitoAnnotations;
import org.springframework.web.server.ServerWebExchange;
import com.fasterxml.jackson.databind.JsonNode;

public class MqdConsentServiceTest {

    @InjectMocks
    private MqdConsentService mqdConsentService;

    @Mock
    private ServerWebExchange exchange;

    @Mock
    private JsonNode responseBody;

    @Mock
    private ConsentResponseOB consentResponse;

    @Before
    public void setup() {
        MockitoAnnotations.openMocks(this);
    }

    @Test
    public void testProcessConsentRequest_ValidGetRequest() throws Exception {
        // Arrange: Configurando um Exchange para ter a URI e método corretos
        when(exchange.getOriginalRequestUri()).thenReturn("/consents");
        when(exchange.getRequest().getMethod()).thenReturn(HttpMethod.GET);
        when(mqdConsentService.getResponseBody(exchange)).thenReturn(responseBody);
        
        // Act: Chamando o método que queremos testar
        mqdConsentService.processConsentRequest(exchange);
        
        // Assert: Verificando se o processamento foi feito corretamente
        verify(mqdConsentService).sendConsentData(any(JsonNode.class), eq(exchange));
        verify(log).info(contains("Feature Toggle is enabled. Sending consent data."));
    }

    @Test
    public void testProcessConsentRequest_NotAGetRequest() {
        // Arrange: Configurando um Exchange para ter uma URI incorreta ou método diferente de GET
        when(exchange.getOriginalRequestUri()).thenReturn("/consents");
        when(exchange.getRequest().getMethod()).thenReturn(HttpMethod.POST);
        
        // Act: Chamando o método
        mqdConsentService.processConsentRequest(exchange);
        
        // Assert: Verificando que a mensagem de pulo foi logada e o método não fez nada
        verify(log).info(contains("Skipping processing"));
        verify(mqdConsentService, never()).sendConsentData(any(JsonNode.class), eq(exchange));
    }

    @Test
    public void testProcessConsentRequest_ThrowsException() throws Exception {
        // Arrange: Forçando uma exceção ao processar o request
        when(exchange.getOriginalRequestUri()).thenReturn("/consents");
        when(exchange.getRequest().getMethod()).thenReturn(HttpMethod.GET);
        when(mqdConsentService.getResponseBody(exchange)).thenThrow(new IOException("Test exception"));

        // Act
        try {
            mqdConsentService.processConsentRequest(exchange);
        } catch (Exception e) {
            // Assert: Verifica se o log de erro foi chamado
            verify(log).error(contains("Error processing consent request"));
        }
    }
}

Sistema de Controle de Acesso para Condomínios

O Sistema desenvolvido se baseia na elaboração de um software de controle de acesso para condomínios na linguagem .NET estudada na disciplina de Linguagem de Programação 4. 

Em segurança, especialmente segurança física, o termo controle de acesso é uma referência à prática de permitir o acesso a uma propriedade, apenas para pessoas autorizadas, e são tecnologias que restringem tal acesso, tentando garantir a segurança de pessoas e bens e impedindo o fluxo de indivíduos não-autorizados.

Tendo em vista o exposto acima, realizamos a criação de CRUDs (criação, consulta, atualização e deleção) para o cadastro de condôminos, veículos, visitantes e funcionários de um condomínio para gerenciamento da movimentação (entrada e saída) de pessoas nas áreas internas de um condomínio.

O cadastro conta com campos para dados pessoais como Nome Completo, CPF, Número do Apartamento, Telefone e Foto, permitindo assim maior rastreabilidade em casos de necessidade.

Trata-se de um sistema para uso do administrativo de um condomínio, e tem como objetivo promover a segurança em relação ao tráfego de pessoas através da obtenção de dados dos mesmos.

Nosso sistema oferece a possibilidade de cadastros completos (e com upload de imagens) permitindo rápida identificação e maior qualidade no controle do acesso.

Equipe:

Dilan Campos de Lima (SP3013359)
Fabricio Teixeira da Silva (SP3013472)
Mateus Santana Joaquim (SP3014266)
Ramon Souza de Oliveira (SP3013367)
Yasmin Cordeiro Assis (SP3021645)
