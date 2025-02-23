using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using Utils;
using GamePlay.StoryV2;
namespace GamePlay.Story.UI
{
    public class TextureAddressHolder : MonoBehaviour
    {
        public string textureAddress;
    }

    public class TipGrid : MonoBehaviour
    {
        public RectTransform canvasRectTransform;  // Reference to the Canvas RectTransform
        private Queue<string> imageQueue = new Queue<string>();  // Queue to manage image loading
        private bool isLoading = false;  // Flag to check if an image is currently being loaded
        private float totalHeight = 0;  // Total height of all loaded images
        public bool hasClick;
        public AnimationCurve SlideCurve;
        // public AnimationCurve FadeCurve;

        // Method to add an image using an addressable address
        public void AddImage(string linkID)
        {

            imageQueue.Enqueue(linkID);
            if (!isLoading)
            {
                StartCoroutine(ProcessQueue());
            }
        }

        private void AddEventTrigger(Button button)
        {
            // EventTrigger eventTrigger = button.gameObject.AddComponent<EventTrigger>();

            // EventTrigger.Entry entry = new EventTrigger.Entry();
            // entry.eventID = EventTriggerType.PointerClick;
            // entry.callback.AddListener((data) => { OnButtonClick((PointerEventData)data); });

            // eventTrigger.triggers.Add(entry);
            button.onClick.AddListener(
                ()=>{
                    OnButtonClick(button);
                }
            );
        }

        private void OnButtonClick(Button button)
        {
            // Handle the button click event
            //ScriptResolver.IsMouseOverTips = true;
            if (TipPresenter.Instance.IsOpened) return;
            ScriptResolverV2.Instance.hasClick = true; // block one click
            StartCoroutine(FadeAndExpand(button.GetComponent<Image>(),button.GetComponent<RectTransform>(), button.GetComponent<TextureAddressHolder>()));

            // Stop event propagation
            //EventSystem.current.SetSelectedGameObject(null);
        }


        // Coroutine to process the image queue
        private IEnumerator ProcessQueue()
        {
            isLoading = true;
            while (imageQueue.Count > 0)
            {
                string address = imageQueue.Dequeue();
                yield return StartCoroutine(LoadAndAnimateImage(address));
            }
            isLoading = false;
        }

        private void Present(string linkID)
        {
            var windowTexture = StoryUtils.LoadResource<Texture>($"Tips/TipsWindow_{linkID}.png");
            var tipTexture = StoryUtils.LoadResource<Texture>($"Tips/Tips_{linkID}.png");
            //ScriptResolver.IsMouseOverTips = false;
            TipPresenter.Instance.Present(tipTexture, windowTexture);
        }
        private IEnumerator FadeAndExpand(Image image, RectTransform rectTransform, TextureAddressHolder holder)
        {
            float duration = 0.5f;
            float elapsedTime = 0f;

            Color originalColor = image.color;
            Vector2 originalSize = rectTransform.sizeDelta;
            Vector2 expandedSize = originalSize * 1.5f;

            float moveAmount = originalSize.y; // Height to move other images up
            List<RectTransform> rectsToMove = new List<RectTransform>();
            Debug.Log($"TIP ID CLICK: {holder.textureAddress}");
            Present(holder.textureAddress);
            // Collect rects to move
            foreach (Transform child in canvasRectTransform)
            {
                RectTransform childRect = child.GetComponent<RectTransform>();
                if (childRect != null && childRect.anchoredPosition.y < rectTransform.anchoredPosition.y)
                {
                    rectsToMove.Add(childRect);
                }
            }
            var basePosition = rectTransform.anchoredPosition;
            while (elapsedTime < duration)
            {
                float t = elapsedTime / duration;
                image.color = Color.Lerp(originalColor, new Color(originalColor.r, originalColor.g, originalColor.b, 0), t);
                rectTransform.sizeDelta = Vector2.Lerp(originalSize, expandedSize, t);

                // Calculate the offset to keep the image centered
                Vector2 offset = (rectTransform.sizeDelta - originalSize) / 2; /// 2;
                Vector2 mul = new Vector2(1, -1);
                rectTransform.anchoredPosition = basePosition - offset * mul; //  * Time.deltaTime / duration

                // Move other images up gradually
                foreach (RectTransform rect in rectsToMove)
                {
                    rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, rect.anchoredPosition.y + (moveAmount * Time.deltaTime / duration));
                }

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Final adjustment after the animation
            // foreach (RectTransform rect in rectsToMove)
            // {
            //     rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, rect.anchoredPosition.y + moveAmount);
            // }

            image.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
            rectTransform.sizeDelta = expandedSize;

            Destroy(image.gameObject);

            totalHeight -= originalSize.y;
            // ScriptResolver.IsMouseOverTips = false;
        }


        private IEnumerator FadeOut(Image image)
        {
            float duration = 0.5f;
            float elapsedTime = 0f;

            Color originalColor = image.color;

            while (elapsedTime < duration)
            {
                float t = elapsedTime / duration;
                image.color = Color.Lerp(originalColor, new Color(originalColor.r, originalColor.g, originalColor.b, 0), t);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            image.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
            Destroy(image.gameObject);
        }

        public void FadeAllImages()
        {
            // imageQueue.Clear()l;

            foreach (Transform child in canvasRectTransform)
            {
                Image image = child.GetComponent<Image>();
                if (image != null)
                {
                    StartCoroutine(FadeOut(image));
                }
            }
            totalHeight = 0;
        }


        // Coroutine to load and animate the image
        private IEnumerator LoadAndAnimateImage(string linkID)
        {
            // Load the texture from the addressable assets
            var address = $"Assets/Addressables/Tips/Summary_{linkID}.png";
            var handle = Addressables.LoadAssetAsync<Texture>(address);
            yield return handle;

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                Texture loadedTexture = handle.Result;

                // Create a new Texture2D from the loaded Texture
                Texture2D texture2D = ConvertTextureToTexture2D(loadedTexture);

                // Create a new Sprite from the Texture2D
                Sprite newSprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f));

                // Create a new GameObject with an Image component
                GameObject newImageObject = new GameObject("DynamicImage");
                newImageObject.transform.SetParent(canvasRectTransform, false);

                Image imageComponent = newImageObject.AddComponent<Image>();
                newImageObject.AddComponent<GraphicRaycaster>();
                imageComponent.sprite = newSprite;
                Button button = newImageObject.AddComponent<Button>();
                TextureAddressHolder holder = newImageObject.AddComponent<TextureAddressHolder>();
                holder.textureAddress = linkID;

                // Adjust the RectTransform
                RectTransform rectTransform = newImageObject.GetComponent<RectTransform>();
                rectTransform.localScale = Vector3.one;

                // Calculate and set the height based on aspect ratio
                float aspectRatio = (float)texture2D.width / texture2D.height;
                float height = canvasRectTransform.rect.width / aspectRatio;
                rectTransform.sizeDelta = new Vector2(canvasRectTransform.rect.width, height);

                // Set anchors and pivot to top-left
                rectTransform.anchorMin = new Vector2(0, 1);
                rectTransform.anchorMax = new Vector2(0, 1);
                rectTransform.pivot = new Vector2(0, 1);

                // Set initial position off-screen to the left
                rectTransform.anchoredPosition = new Vector2(-canvasRectTransform.rect.width, -totalHeight);

                // Calculate the new total height after adding this image
                totalHeight += rectTransform.sizeDelta.y;

                //button.onClick.AddListener(() => StartCoroutine(FadeAndExpand(imageComponent, rectTransform)));
                AddEventTrigger(button);
                // Start the slide-in animation from the left
                yield return StartCoroutine(SlideInFromLeft(rectTransform, -totalHeight + rectTransform.sizeDelta.y));
            }
            else
            {
                Debug.LogError("Failed to load image from address: " + handle.Status);
            }
        }

        // Method to convert Texture to Texture2D
        private Texture2D ConvertTextureToTexture2D(Texture texture)
        {
            // Create a RenderTexture
            RenderTexture renderTexture = RenderTexture.GetTemporary(
                texture.width,
                texture.height,
                0,
                RenderTextureFormat.Default,
                RenderTextureReadWrite.Linear);

            // Copy texture to the render texture
            Graphics.Blit(texture, renderTexture);

            // Create a new Texture2D and read the RenderTexture into it
            Texture2D texture2D = new Texture2D(texture.width, texture.height, TextureFormat.RGBA32, false);
            RenderTexture.active = renderTexture;
            texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
            texture2D.Apply();

            // Release the render texture
            RenderTexture.active = null;
            RenderTexture.ReleaseTemporary(renderTexture);

            return texture2D;
        }

        // Coroutine to animate the image sliding in from the left
        private IEnumerator SlideInFromLeft(RectTransform rectTransform, float finalYPosition)
        {
            float duration = 0.5f;  // Duration of the animation
            Vector2 startPosition = rectTransform.anchoredPosition;
            Vector2 endPosition = new Vector2(0, finalYPosition);
            float elapsedTime = 0f;
            var curve = SlideCurve; // new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));

            while (elapsedTime < duration)
            {
                float t = elapsedTime / duration;
                float curveValue = curve.Evaluate(t); // Evaluate the curve at the current time
                rectTransform.anchoredPosition = Vector2.Lerp(startPosition, endPosition, curveValue);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            rectTransform.anchoredPosition = endPosition;
        }
    }
}